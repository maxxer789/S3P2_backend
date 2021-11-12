using AccountService.Models;
using AccountService.Models.ViewModels;
using AccountService.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Logic
{
    public class AccountLogic
    {
        private readonly IAccountRepo _repo;
        private readonly IMapper _mapper;
        public AccountLogic(IAccountRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public AccountViewModel Login(AccountLoginViewModel accountLogin)
        {
            Account account = _repo.Login(_mapper.Map<Account>(accountLogin));
            return _mapper.Map<AccountViewModel>(account);
        }

        public AccountViewModel Register(AccountLoginViewModel accountRegister)
        {
            if (_repo.AccountExists(_mapper.Map<Account>(accountRegister)))
            {
                return null;
            }

            accountRegister.Password = BCrypt.Net.BCrypt.HashPassword(accountRegister.Password);

            return _mapper.Map<AccountViewModel>(_repo.Register(_mapper.Map<Account>(accountRegister)));
        }
    }
}
