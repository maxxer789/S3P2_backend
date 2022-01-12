using GroupService.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupService.Context
{
    public class GroupContext : DbContext
    {
        public GroupContext(DbContextOptions<GroupContext> options) : base(options)
        {

        }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Message> GroupMessages { get; set; }
    }
}
