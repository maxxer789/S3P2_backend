using AutoMapper;
using GroupService.Models;
using GroupService.Models.ViewModels;

namespace GroupService.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GroupViewModel>().ReverseMap();
        }
    }
}
