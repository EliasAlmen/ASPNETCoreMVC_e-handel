using ehandel.DataAccess.Repository.IRepository;
using ehandel.Models;
using ehandel.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehandel.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task UpdateAsync(ProductVM obj);
    }
}
