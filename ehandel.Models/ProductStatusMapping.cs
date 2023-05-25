using ehandel.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ehandel.Models
{
    [PrimaryKey(nameof(ProductId), nameof(ProductStatusId))]
    public class ProductStatusMapping
    {
        public int ProductId { get; set; }
        [JsonIgnore]
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int ProductStatusId { get; set; }
        [ForeignKey("ProductStatusId")]
        public ProductStatus ProductStatus { get; set; }
    }
}
