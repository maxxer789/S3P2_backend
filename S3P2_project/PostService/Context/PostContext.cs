using Microsoft.EntityFrameworkCore;
using PostService.Models;

namespace PostService.Context
{
    public class PostContext : DbContext
    {
        public PostContext(DbContextOptions<PostContext> options) : base (options)
        {

        }

        public virtual DbSet<Post> Post { get; set; }
    }
}
