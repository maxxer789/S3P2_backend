using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Controllers
{
    [Route("Accounts")]
    [ApiController]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}