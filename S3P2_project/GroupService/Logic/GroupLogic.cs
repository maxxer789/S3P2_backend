using AutoMapper;
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
    }
}
