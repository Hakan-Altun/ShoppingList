using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ProductDetailId { get; set; }
        public string? ProductImage { get; set; }
        public string? CategoryName { get; set; }
        public int? CategoryId { get; set; }
        public int? ListId { get; set; }
        public bool ProductStatus { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public IFormFile? ImageFile { get; set; }
        public Category Category { get; set; }
        public ProductDetail ProductDetail { get; set; }
        public ICollection<ListProduct> ListProducts { get; set; }
    }
}
