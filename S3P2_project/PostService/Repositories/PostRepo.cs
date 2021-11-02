using PostService.Context;
using PostService.Models;
using System.Collections.Generic;
using System.Linq;

namespace PostService.Repositories
{
    public class PostRepo : IPostRepo
    {
        //private readonly PostContext _context;
        public PostRepo()
        {
            //_context = context;
        }

        public Post GetPostById(int id)
        {
            return new Post();
            //return _context.Post.Where(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Post> GetPosts()
        {
            return new List<Post>();
            //return _context.Post.AsEnumerable();
        }
    }
}
