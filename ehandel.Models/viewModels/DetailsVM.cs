using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehandel.Models.viewModels
{
    public class DetailsVM
    {
        public IEnumerable<Product> RelatedProducts { get; set; }
        public Product Product { get; set; }
    }
}
