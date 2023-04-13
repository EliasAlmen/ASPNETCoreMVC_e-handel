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
    public class ContactUsRepository : Repository<ContactUs>, IContactUsRepository
    {
        private ApplicationDbContext _db;

        public ContactUsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ContactUs obj)
        {
            _db.ContactUs.Update(obj);
        }
    }
}
