using Microsoft.AspNetCore.Identity;

namespace Challenge.Entities
{
    public class User : IdentityUser
    {
        public bool IsActive { get; set; }
    }
}
