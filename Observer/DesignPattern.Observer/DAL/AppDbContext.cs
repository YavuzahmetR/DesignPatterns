using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace DesignPattern.Observer.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DesignPatternChain;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public DbSet<WelcomeMessage> WelcomeMessages { get; set; } = null!;
        public DbSet<Discount> Discounts { get; set; } = null!;
        public DbSet<UserSpecifiedAction> UserSpecifiedActions { get; set; } = null!;
    }
}
