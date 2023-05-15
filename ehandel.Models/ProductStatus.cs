using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ehandel.Models
{
    public class ProductStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        [JsonIgnore]
        public ICollection<ProductStatusMapping> ProductStatusMappings { get; set; }

    }
}
