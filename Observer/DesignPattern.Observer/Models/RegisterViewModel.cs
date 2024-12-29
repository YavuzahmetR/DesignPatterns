namespace DesignPattern.Observer.Models
{
    public class RegisterViewModel
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? City { get; set; } 
        public string? District { get; set; } 
    }
}
