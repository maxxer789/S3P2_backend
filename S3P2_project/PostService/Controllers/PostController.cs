using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostService.Repositories;
using PostService.Models.ViewModels;

namespace PostService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepo _repo;
        private readonly IMapper _mapper;
        public PostController(IPostRepo postRepo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = postRepo;
        }

        [HttpGet]
        [Route("all"), ActionName("PostOverview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllPosts()
        {
            ICollection<PostViewModel> posts = _mapper.Map<ICollection<PostViewModel>>(_repo.GetPosts());
            return Ok(posts);
        }

        [HttpGet]
        [Route("{id}"), ActionName("PostDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPostById(int id)
        {
            PostViewModel post = _mapper.Map<PostViewModel>(_repo.GetPostById(id));
            return Ok(post);
        }
    }
}
