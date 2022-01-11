using GroupService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupService.Repositories
{
    public interface IGroupRepo
    {
        public Group GetGroup(int id);
        public Group CreateGroup(string name);
        public Group EditGroup(Group group);
        public bool DeleteGroup(int Id);
    }
}
