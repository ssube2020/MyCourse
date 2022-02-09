using Microsoft.AspNetCore.Identity;

namespace MyCourse.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string Name { get; set; }
        public ApplicationUser()
        {

        }

    }
}
