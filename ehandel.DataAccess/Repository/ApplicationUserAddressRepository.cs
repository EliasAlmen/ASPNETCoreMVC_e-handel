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
    public class ApplicationUserAddressRepository : Repository<ApplicationUserAddress>, IApplicationUserAddressRepository
    {
        private ApplicationDbContext _db;

        public ApplicationUserAddressRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        // No interactions with DB == no AsyncAwaited
        public void Update(ApplicationUserAddress obj)
        {
           _db.ApplicationUserAddresses.Update(obj);
        }
    }
}
