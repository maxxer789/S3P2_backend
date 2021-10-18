using AutoMapper;
using PostService.Models;
using PostService.Models.ViewModels;

namespace PostService.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostViewModel>();
        }
    }
}
