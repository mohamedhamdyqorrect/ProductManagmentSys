using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Models
{
    public class ProductDetail
    {

        [Key]
        public int ProductDetailId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(2048)")]
        public string ImageUrl { get; set;}
        public int Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        [Required]
        public int ProductTypeID { get; set; }
        public decimal DiscountPercent { get; set; }
    }
}
