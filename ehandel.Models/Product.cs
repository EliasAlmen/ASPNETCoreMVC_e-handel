using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ehandel.Models
{
	public class Product
	{
		public int Id { get; set; }
        public string SKU { get; set; } = Guid.NewGuid().ToString();
        [Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		[Range(1, 999999)]
		[Column(TypeName = "money")]
		public double Price { get; set; }
		[ValidateNever]
		public string ImageUrl { get; set; }
		[ValidateNever]
		public string CreatedDateTime { get; set; } = DateTime.Now.ToString("g");


		[Required]
		[Display(Name = "Rating")]
		public int ProductRatingId { get; set; }
		[ForeignKey("ProductRatingId")]
		[ValidateNever]
        public ProductRating ProductRating { get; set; }

        [ValidateNever]
        public ICollection<ProductStatusMapping> ProductStatusMappings { get; set; }


        [Required]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
		public Category Category { get; set; }

    }
}
