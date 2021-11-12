using AccountService.Context;
using AccountService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private readonly AccountContext _context;
        public AccountRepo(AccountContext context)
        {
            _context = context; 
        }

        public bool AccountExists(Account account)
        {
            if(_context.Accounts.SingleOrDefault(a => a.Username == account.Username) != null)
            {
                return true;
            }
            return false;
        }

        public Account Login(Account account)
        {
            Account acc = _context.Accounts.SingleOrDefault(a => a.Username == account.Username);

            bool validPassword = BCrypt.Net.BCrypt.Verify(account.Password, acc.Password);

            if (validPassword)
            {
                return acc;
            }
            else
            {
                return null;
            }
        }

        public Account Register(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return account;
        }
    }
}
