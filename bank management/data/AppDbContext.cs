using bank_management.models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace bank_management.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<employee> Employees { get; set; }
        public DbSet<branch> Branches { get; set; }
        public DbSet<customer> Customers { get; set; }
        public DbSet<account> Accounts { get; set; }
        public DbSet<transaction> Transactions { get; set; }
        public DbSet<bankcard> bankcards  { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<customer>()
                .HasOne(c => c.bankcard)
                .WithOne(b => b.customer)
                .HasForeignKey<customer>(c => c.bankcardid);

            base.OnModelCreating(modelBuilder);
        }
    }
}

  
