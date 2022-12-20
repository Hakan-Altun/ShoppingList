using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.UserDTOs
{
    public class UserRequestDTO
    {
        public int UserId { get; set; }
        public int? RoleId { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}
