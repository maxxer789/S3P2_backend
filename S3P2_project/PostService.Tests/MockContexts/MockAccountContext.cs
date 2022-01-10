using AccountService.Models;
using AccountService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Tests.MockContexts
{
    class MockAccountContext : IAccountRepo
    {
        private List<Account> MockAccounts = new List<Account>();
        public MockAccountContext()
        {
            PopulateAccounts();
        }

        public bool AccountExists(Account account)
        {
           return MockAccounts.SingleOrDefault(a => a.Username == account.Username) != null;
        }

        public Account GetAccountFromId(int Id)
        {
            return MockAccounts.SingleOrDefault(a => a.Id == Id);
        }

        public Account Login(Account account)
        {
            return MockAccounts.SingleOrDefault(a => a.Username == account.Username && a.Password == account.Password);
        }

        public Account Register(Account account)
        {
            account.Id = MockAccounts[^1].Id + 1;
            account.Posts = new List<AccountPost>();
            MockAccounts.Add(account);
            return account;
        }
        private void PopulateAccounts()
        {
            for (int i = 0; i < 4; i++)
            {
                Account account = new Account();
                account.Id = i;
                account.Username = "Username" + i;
                account.Password = BCrypt.Net.BCrypt.HashPassword("password" + i);
                account.Posts = new List<AccountPost>();

                MockAccounts.Add(account);
            }
        }
    }
}
