using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AuthMVC.Models;

namespace AuthMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AuthMVC.Models.Fruit> Fruit { get; set; }
        public DbSet<AuthMVC.Models.Image> Images { get; set; }

    }
}