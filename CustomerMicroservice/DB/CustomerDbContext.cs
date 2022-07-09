using CustomerMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerMicroservice.DB
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext (DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerDetails>().HasData(
                new CustomerDetails { CustomerId = "JhonSmith", Name = "Jhonathon Smith", Address = "Dumdum", DateOfBirth = "05-09-1997", PanNumber = "CGLBP002" }
            );
        }
        public DbSet<CustomerDetails> customers { get; set; }
    }
}
