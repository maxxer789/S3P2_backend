using AccountService.Models;
using AccountService.Models.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Account, AccountLoginViewModel>().ReverseMap();
            CreateMap<Account, AccountViewModel>().ReverseMap();
        }
    }
}
