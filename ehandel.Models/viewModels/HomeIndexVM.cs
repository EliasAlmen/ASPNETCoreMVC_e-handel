using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehandel.Models.viewModels
{
    public class HomeIndexVM
    {
        public IEnumerable<Product> AllProducts { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
    }
}
