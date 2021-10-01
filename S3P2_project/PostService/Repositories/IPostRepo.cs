using PostService.Models;
using System.Collections.Generic;

namespace PostService.Repositories
{
    public interface IPostRepo
    {
        public IEnumerable<Post> GetPosts();
    }
}
