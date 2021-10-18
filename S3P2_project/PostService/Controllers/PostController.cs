using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostService.Repositories;
using PostService.Models.ViewModels;
using PostService.Logic;

namespace PostService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private PostLogic _logic;
        public PostController(IPostRepo postRepo, IMapper mapper)
        {
            _logic = new PostLogic(postRepo, mapper);
        }

        [HttpGet]
        [Route("all"), ActionName("PostOverview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllPosts()
        {
            ICollection<PostViewModel> posts = _logic.GetPosts();
            return Ok(posts);
        }

        [HttpGet]
        [Route("{id}"), ActionName("PostDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPostById(int id)
        {
            PostViewModel post = _logic.GetPostById(id);
            return Ok(post);
        }
    }
}
