using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class List
    {
        public int ListId { get; set; }
        public int UserId { get; set; }
        public string ListName { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
        public bool IsDeleted { get; set; } = false; 
        public User User { get; set; }
        public ICollection<ListProduct> ListProducts { get; set; }
    }

}
