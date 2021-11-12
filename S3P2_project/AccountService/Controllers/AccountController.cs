using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountService.Models.ViewModels;
using AccountService.Logic;

namespace AccountService.Controllers
{
    [Route("Accounts")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly AccountLogic _logic;
        public AccountController(AccountLogic logic)
        {
            _logic = logic;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] AccountLoginViewModel userLogin)
        {
            AccountViewModel Account = _logic.Login(userLogin);

            if (Account != null)
            {
                return Ok(Account);
            }

            return BadRequest("User doesn't Exist");
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] AccountLoginViewModel userRegister)
        {
            AccountViewModel NewAccount = _logic.Register(userRegister);

            if (NewAccount != null)
            {
                return CreatedAtAction("Register", NewAccount);
            }

            return StatusCode(409, "Username already in use");
        }
    }
}