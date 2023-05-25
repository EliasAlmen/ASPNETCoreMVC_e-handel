using ehandel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehandel.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IContactUsRepository ContactUs { get; }
        IProductRepository Product { get; }
        IProductRatingRepository ProductRating { get; }
        IProductStatusRepository ProductStatus { get; }
        IProductStatusMappingRepository ProductStatusMapping { get; }
        IApplicationUserAddressRepository ApplicationUserAddress { get; }
        IApplicationUserCompanyRepository ApplicationUserCompany { get; }
        IApplicationUserRepository ApplicationUser { get; }

        Task SaveAsync();
    }
}
