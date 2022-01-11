using GroupService.Context;
using GroupService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupService.Repositories
{
    public class GroupRepo : IGroupRepo
    {
        private readonly GroupContext _context;
        public GroupRepo(GroupContext context)
        {
            _context = context;
        }

        public Group CreateGroup(string name)
        {
            Group newGroup = new Group
            {
                GroupName = name
            };

            _context.Groups.Add(newGroup);
            _context.SaveChanges();

            return newGroup;
        }

        public bool DeleteGroup(int Id)
        {
            Group toBeDeleted = GetGroup(Id);
            if(toBeDeleted != null)
            {
                _context.Groups.Remove(toBeDeleted);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Group EditGroup(Group group)
        {
            _context.Groups.Update(group);
            _context.SaveChanges();
            return group;
        }

        public Group GetGroup(int id)
        {
            return _context.Groups.SingleOrDefault(g => g.Id == id);
        }
    }
}
