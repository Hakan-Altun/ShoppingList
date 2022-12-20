using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductDetail
    {
        public int ProductDetailId { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public string? ProductImage { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Quantity { get; set; }
        public string? Brand { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Product Product { get; set; }
    }
}
