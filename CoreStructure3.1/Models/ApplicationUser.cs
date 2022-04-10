using Microsoft.AspNetCore.Identity;

namespace CoreStructure3._1.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}