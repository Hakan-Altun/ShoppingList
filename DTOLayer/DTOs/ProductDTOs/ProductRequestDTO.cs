using Entities;
using Microsoft.AspNetCore.Http;

namespace DTOLayer.DTOs.ProductDTOs
{
    public class ProductRequestDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ProductDetailId { get; set; }
        public string? ProductImage { get; set; }
        public string? CategoryName { get; set; }
        public  List<Category> CategoryNames { get; set; }
    }
}
