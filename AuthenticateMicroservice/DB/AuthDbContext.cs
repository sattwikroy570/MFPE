using AuthenticateMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticateMicroservice.DB
{
    public class AuthDbContext: DbContext
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCredentails>().HasData(
                 new UserCredentails { UserName = "Manager", Password = "1234", Roles = "Employee" },
                 new UserCredentails { UserName = "JhonSmith", Password = "0000", Roles = "Customer" }
            );
        }
        public DbSet<UserCredentails> clientList { get; set; }
    }
}
