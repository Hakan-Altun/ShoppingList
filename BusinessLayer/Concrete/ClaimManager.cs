using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ClaimManager
    {
        public ClaimsPrincipal BuildClaim(string userEmail, string userRole)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,userEmail),
                new Claim(ClaimTypes.Role,userRole)
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, "Login");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            return principal;
        }
    }
}
