using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.ProductDTOs
{
    public class ProductListDTO
    {
        public List List { get; set; }
        public List<Product> Products { get; set; }
    }
}
