using Microsoft.AspNetCore.Identity;

namespace IdentitySetupTest5.Model
{
    public class ApplicationUser : IdentityUser 
    {
        public string Name { get; set;}
    }
}
