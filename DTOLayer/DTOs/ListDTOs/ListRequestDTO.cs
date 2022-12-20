using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.ListDTOs
{
    public class ListRequestDTO
    {
        public int ListId { get; set; }
        public int UserId { get; set; }
        public string ListName { get; set; }
    }
}
