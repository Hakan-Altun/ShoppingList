using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.LoginDTOs
{
    public class LoginDTO
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public bool RememberMe { get; set; }
    }
}
