using ehandel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehandel.DataAccess.Repository.IRepository
{
    public interface IProductStatusMappingRepository : IRepository<ProductStatusMapping>
    {
        void Update(ProductStatusMapping obj);
        //Task<List<ProductStatusMapping>> GetByProductIdAsync(int productId);
        //Task<ProductStatusMapping> GetByProductIdAndStatusIdAsync(int productId, int productStatusId);
    }
}
