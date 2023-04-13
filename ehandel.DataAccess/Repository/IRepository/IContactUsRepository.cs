using ehandel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehandel.DataAccess.Repository.IRepository
{
    public interface IContactUsRepository : IRepository<ContactUs>
    {
        void Update(ContactUs obj);
    }
}
