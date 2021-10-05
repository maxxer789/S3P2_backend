using PostService.Models;
using System.Collections.Generic;

namespace PostService.Repositories
{
    public interface IPostRepo
    {
        public IEnumerable<Post> GetPosts();
        public Post GetPostById(int id);
    }
}
