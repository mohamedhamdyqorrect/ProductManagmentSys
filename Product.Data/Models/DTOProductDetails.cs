using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Data.Models
{
   public class DTOProductDetails
    {

        public int ProductDetailId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        public int ProductTypeID { get; set; }
        public decimal DiscountPercent { get; set; }
    }
}
