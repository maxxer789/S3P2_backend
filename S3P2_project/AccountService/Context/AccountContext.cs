using AccountService.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Context
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountPost> AccountPosts { get; set; }

    }
}
