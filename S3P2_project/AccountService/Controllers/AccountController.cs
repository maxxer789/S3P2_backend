using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountService.Models.ViewModels;
using AccountService.Logic;
using System.Net.Http;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AccountService.Models;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AccountService.Controllers
{
    [Route("Accounts")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly AccountLogic _logic;
        private readonly TokenSettings _tokenSettings;
        public AccountController(AccountLogic logic, IOptions<TokenSettings> tokenSettings)
        {
            _logic = logic;
            _tokenSettings = tokenSettings.Value;
        }

        [HttpGet]
        [Route("{Id}/Posts")]
        public IActionResult PostsFromAccount(int Id)
        {
            AccountViewModel account = _logic.GetAccountFromId(Id);
            if(account != null)
            {
                return Ok(account);
            }
            return BadRequest("User doesn't exist");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] AccountLoginViewModel userLogin)
        {
            AccountViewModel Account = _logic.Login(userLogin);

            if (Account != null)
            {
                SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.JWTKey.ToString()));
                SigningCredentials credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: credentials
                    );

                string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { tokenString });
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