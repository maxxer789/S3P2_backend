using GroupService.Logic;
using GroupService.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GroupService.Controllers
{
    [Route("Groups")]
    [ApiController]
    public class GroupController : Controller
    {
        private readonly GroupLogic _logic;
        public GroupController(GroupLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult Index(int Id)
        {
            GroupViewModel group = _logic.GetGroup(Id);

            if(group != null)
            {
                return Ok(group);
            }

            return NotFound($"Group with Id:{Id} not found");
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult UpdateGroup([FromBody] GroupViewModel groupViewModel)
        {
            groupViewModel = _logic.EditGroup(groupViewModel);

            if(groupViewModel != null)
            {
                return Ok(groupViewModel);
            }

            return NotFound($"Group with Id:{groupViewModel.Id} not found");
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult DeleteGroup([FromBody] GroupViewModel groupViewModel)
        {
            if (_logic.DeleteGroup(groupViewModel.Id))
            {
                return Ok(groupViewModel);
            }

            return NotFound($"Group with Id:{groupViewModel.Id} not found");
        }
        [HttpPost]
        public IActionResult CreateGroup([FromBody] GroupCreationViewModel groupCreationViewModel)
        {
            GroupViewModel newGroup = _logic.CreateGroup(groupCreationViewModel);
            return Ok(newGroup);
        }
    }
}