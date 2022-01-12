using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Service.Tests.MockContexts;
using AccountService.Logic;
using AccountService.Models;
using AccountService.Models.ViewModels;
using AutoMapper;
using AccountService.Repositories;

namespace Service.Tests.Accounts
{
    [TestClass]
    public class AccountTests
    {
        private readonly AccountLogic _logic;
        private readonly IMapper _mapper;

        public AccountTests()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Account, AccountViewModel>().ReverseMap();
                cfg.CreateMap<Account, AccountLoginViewModel>().ReverseMap();
            });

            _mapper = new Mapper(config);

            IAccountRepo IAccountRepo = new MockAccountContext();
            _logic = new AccountLogic(IAccountRepo, _mapper);
        }

        [TestMethod]
        public void AccountById_ValidId()
        {
            int id = 1;

            AccountViewModel account = _logic.GetAccountFromId(id);

            Assert.AreEqual(id, account.Id);
        }

        [TestMethod]
        public void AccountById_InvalidId()
        {
            int id = 1841;

            AccountViewModel account = _logic.GetAccountFromId(id);

            Assert.IsNull(account);
        }

        [TestMethod]
        public void CreateAccount_NewAccount()
        {
            AccountLoginViewModel newAccount = new AccountLoginViewModel
            {
                Username = "NewUser",
                Password = "NewPassword"
            };
            AccountViewModel createdAccount = _logic.Register(newAccount);

            Assert.IsNotNull(createdAccount.Id);
        }

        [TestMethod]
        public void CreateAccount_ExistingAccount()
        {
            AccountLoginViewModel newAccount = new AccountLoginViewModel
            {
                Username = "Username1",
                Password = "NewPassword"
            };
            AccountViewModel createdAccount = _logic.Register(newAccount);

            Assert.IsNull(createdAccount);
        }
    }
}
