using ehandel.DataAccess.Data;
using ehandel.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehandel.DataAccess.Repository
{
    public class Service : IService
    {
        private ApplicationDbContext _db;

        public Service(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            ContactUs = new ContactUsRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }
        public IContactUsRepository ContactUs { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
