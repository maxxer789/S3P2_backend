using AutoMapper;
using GroupService.Models;
using GroupService.Models.ViewModels;
using GroupService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupService.Logic
{
    public class GroupLogic
    {
        private readonly IGroupRepo _repo;
        private readonly IMapper _mapper;
        public GroupLogic(IGroupRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public GroupViewModel GetGroup(int id)
        {
            return _mapper.Map<GroupViewModel>(_repo.GetGroup(id));
        }
        public GroupViewModel CreateGroup(GroupCreationViewModel groupCreationViewModel)
        {
            return _mapper.Map<GroupViewModel>(_repo.CreateGroup(groupCreationViewModel.GroupName));
        }
        public GroupViewModel EditGroup(GroupViewModel group)
        {
            Group groupToBeEdited = _mapper.Map<Group>(group);
            return _mapper.Map<GroupViewModel>(_repo.EditGroup(groupToBeEdited));
        }
        public bool DeleteGroup(int Id)
        {
            return _repo.DeleteGroup(Id);
        }

    }
}
