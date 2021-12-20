using PostService.Context;
using PostService.Models;
using System.Collections.Generic;
using System.Linq;

namespace PostService.Repositories
{
    public class PostRepo : IPostRepo
    {
        private readonly PostContext _context;
        public PostRepo(PostContext context)
        {
            _context = context;
        }

        public Post GetPostById(int id)
        {
            return _context.Post.Where(p => p.Id == id).FirstOrDefault();
        }

        public IReadOnlyList<Post> GetPosts()
        {
            return _context.Post.AsEnumerable().ToList().AsReadOnly();
        }
    }
}
