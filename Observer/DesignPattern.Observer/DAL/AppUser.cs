using Microsoft.AspNetCore.Identity;

namespace DesignPattern.Observer.DAL
{
    public class AppUser:IdentityUser<Guid>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
    }
}
