using ehandel.DataAccess.Data;
using ehandel.DataAccess.Repository.IRepository;
using ehandel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehandel.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        // No interactions with DB == no AsyncAwaited
        public void Update(Category obj)
        {
           _db.Categories.Update(obj);
        }
    }
}
