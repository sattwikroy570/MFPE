using Microsoft.EntityFrameworkCore;
using AccountMicroservice.Models;
using System;
using System.Collections.Generic;

namespace AccountMicroservice.DB
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAccount>().HasData(
                new CustomerAccount { CustomerId = "JhonSmith", CurrentAccountId = 201, SavingsAccountId = 202 }
            );
            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 201, Balance = 1000 },
                new Account { Id = 202, Balance = 500 }
            );
           modelBuilder.Entity<AccountStatement>().OwnsOne(x => x.Statements);
           modelBuilder.Entity<AccountStatement>().HasData(
                    new { AccountId = 202 },
                    new{ AccountId = 201 }
            );
        }
        public DbSet<Account> accounts { get; set; }
        public DbSet<AccountStatement> accountStatements { get; set; }
        public DbSet<CustomerAccount> customerAccounts { get; set; }
    }
}
