using Microsoft.AspNetCore.Identity;

namespace WebDT.Models
{
    public class AppUserModel : IdentityUser
    {
        public string Address { get; set; }
    }
}
