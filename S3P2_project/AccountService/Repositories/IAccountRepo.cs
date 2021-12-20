using AccountService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Repositories
{
    public interface IAccountRepo
    {
        public Account Login(Account account);
        public Account Register(Account account);
        public Account GetAccountFromId(int Id);
        public bool AccountExists(Account account);
    }
}
