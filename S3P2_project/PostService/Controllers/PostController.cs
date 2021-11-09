using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostService.Repositories;
using PostService.Models.ViewModels;
using PostService.Logic;

namespace PostService.Controllers
{
    [Route("Posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private PostLogic _logic;
        public PostController(IPostRepo postRepo, IMapper mapper)
        {
            _logic = new PostLogic(postRepo, mapper);
        }

        [HttpGet]
        [ActionName("PostOverview")]
        public IActionResult GetAllPosts()
        {
            try
            {
                ICollection<PostViewModel> posts = _logic.GetPosts();
                return Ok(posts);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("{id}"), ActionName("PostDetails")]
        public IActionResult GetPostById(int id)
        {
            PostViewModel post = _logic.GetPostById(id);

            if (post.Id > 0)
            {
                return Ok(post);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("hallo"), ActionName("TestController")]
        public IActionResult Hallo()
        {
            return Ok("hallo");
        }
    }
}
