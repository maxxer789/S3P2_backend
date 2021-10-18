using AutoMapper;
using PostService.Models;
using PostService.Models.ViewModels;
using PostService.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PostService.Logic
{
    public class PostLogic
    {
        private readonly IPostRepo _repo;
        private readonly IMapper _mapper;

        public PostLogic(IPostRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public ICollection<PostViewModel> GetPosts()
        {
            ICollection<Post> posts = _repo.GetPosts().ToList();
            ICollection<PostViewModel> postViewModels = _mapper.Map<ICollection<PostViewModel>>(posts);
            return postViewModels;
        }
        public PostViewModel GetPostById(int id)
        {
            PostViewModel post = _mapper.Map<PostViewModel>(_repo.GetPostById(id));
            return post;
        }
    }
}
