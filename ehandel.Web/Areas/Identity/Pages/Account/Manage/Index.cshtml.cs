// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ehandel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ehandel.Web.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Display(Name = "Street address")]
            public string StreetAddress { get; set; }

            [Display(Name = "City")]
            public string City { get; set; }

            [Display(Name = "Postal code")]
            public string PostalCode { get; set; }
            [Display(Name = "Company")]
            public string Company { get; set; }
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            // Retrieve the ApplicationUser associated with the IdentityUser
            var applicationUser = await _userManager.Users
                .OfType<ApplicationUser>()
                .Include(u => u.ApplicationUserAddress)
                .Include(u => u.ApplicationUserCompany)
                .FirstOrDefaultAsync(u => u.UserName == userName);

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                // Set the values of your ApplicationUser properties
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                StreetAddress = applicationUser.ApplicationUserAddress?.StreetName,
                City = applicationUser.ApplicationUserAddress?.City,
                PostalCode = applicationUser.ApplicationUserAddress?.PostalCode,
                Company = applicationUser.ApplicationUserCompany?.CompanyName
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }


            // Update other properties if needed
            var applicationUser = await _userManager.Users
               .OfType<ApplicationUser>()
               .Include(u => u.ApplicationUserAddress)
               .Include(u => u.ApplicationUserCompany)
               .FirstOrDefaultAsync(u => u.UserName == user.UserName);

            applicationUser.FirstName = Input.FirstName;
            applicationUser.LastName = Input.LastName;

            if (applicationUser.ApplicationUserAddress == null)
            {
                // Create a new address if it doesn't exist
                applicationUser.ApplicationUserAddress = new ApplicationUserAddress();
            }
            if (applicationUser.ApplicationUserCompany == null)
            {
                // Create a new address if it doesn't exist
                applicationUser.ApplicationUserCompany = new ApplicationUserCompany();
            }
            applicationUser.ApplicationUserAddress.StreetName = Input.StreetAddress;
            applicationUser.ApplicationUserAddress.City = Input.City;
            applicationUser.ApplicationUserAddress.PostalCode = Input.PostalCode;
            applicationUser.ApplicationUserCompany.CompanyName = Input.Company;


            await _userManager.UpdateAsync(applicationUser);


            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
