using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ListProduct
    {
        public int ListId { get; set; }
        public int ProductId { get; set; }
        public bool ProductStatus { get; set; } = true;
        public Product Product { get; set; }
        public List List { get; set; }
    }
}
