using AccountService.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Context
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountPost> AccountPosts { get; set; }
        public DbSet<AccountGroup> AccountGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountGroup>()
                .Property(ag => ag.Role)
                .HasConversion<int>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
