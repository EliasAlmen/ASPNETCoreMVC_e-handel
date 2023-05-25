using ehandel.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ehandel.Models.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "A product name must at least contian 3 words.")]
        [Display(Name = "Product name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        [ValidateNever]
        [Display(Name = "Product image")]
        public string? ImageUrl { get; set; }
        [Display(Name = "Product rating")]
        public int ProductRatingId { get; set; }
        [Display(Name = "Product category")]
        public int CategoryId { get; set; }
        [ValidateNever] 
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> RatingsList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> StatusList { get; set; }
        [ValidateNever]
        [Display(Name = "Select statuses *multiple choice*")]
        public List<int>? SelectedStatuses { get; set; }

        public static implicit operator Product(ProductVM vm)
        {
            return new Product
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                Price = vm.Price,
                ImageUrl = vm.ImageUrl,
                ProductRatingId = vm.ProductRatingId,
                CategoryId = vm.CategoryId,
                ProductStatusMappings = vm.SelectedStatuses?.Select(statusId => new ProductStatusMapping { ProductStatusId = statusId }).ToList()
            };
        }

        public static implicit operator ProductVM(Product v)
        {
            return new ProductVM
            {
                Id = v.Id,
                Name = v.Name,
                Description = v.Description,
                Price = v.Price,
                ImageUrl = v.ImageUrl,
                ProductRatingId = v.ProductRatingId,
                CategoryId = v.CategoryId,
                SelectedStatuses = v.ProductStatusMappings?.Select(mapping => mapping.ProductStatusId).ToList()
            };
        }
    }
}
