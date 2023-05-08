using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace ehandel.Models;

[PrimaryKey(nameof(ProductId), nameof(ProductStatusId))]
public class ProductStatusMapping
{
    public int ProductId { get; set; }
	[JsonIgnore]
	public Product Product { get; set; }


    public int ProductStatusId { get; set; }
	public ProductStatus ProductStatus { get; set; }
}
