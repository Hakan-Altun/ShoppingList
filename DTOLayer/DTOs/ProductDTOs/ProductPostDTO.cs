using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.ProductDTOs
{
    public class ProductPostDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ProductDetailId { get; set; }
        public string? ProductImage { get; set; }
        public string? CategoryName { get; set; }
        public int? CategoryId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
