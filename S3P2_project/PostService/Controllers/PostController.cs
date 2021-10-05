using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostService.Repositories;

namespace PostService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepo _repo;
        public PostController(IPostRepo postRepo)
        {
            _repo = postRepo;
        }

        [HttpGet]
        [Route("all"), ActionName("PostOverview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllPosts()
        {
            return Ok(_repo.GetPosts());
        }

        [HttpGet]
        [Route("{id}"), ActionName("PostDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPostById(int id)
        {
            return Ok(_repo.GetPostById(id));
        }
    }
}
