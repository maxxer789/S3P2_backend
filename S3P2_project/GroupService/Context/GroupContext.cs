using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupService.Context
{
    public class GroupContext : DbContext
    {
        public GroupContext(DbContextOptions<GroupContext> options) : base(options)
        {

        }
    }
}
