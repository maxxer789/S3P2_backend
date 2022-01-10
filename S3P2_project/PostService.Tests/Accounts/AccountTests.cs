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
    class AccountTests
    {
        private readonly AccountLogic _logic;
        private readonly IMapper _mapper;

        public AccountTests()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Account, AccountViewModel>();
                cfg.CreateMap<Account, AccountLoginViewModel>();
            });

            _mapper = new Mapper(config);

            IAccountRepo IAccountRepo = new MockAccountContext();
            _logic = new AccountLogic(IAccountRepo, _mapper);
        }
    }
}
