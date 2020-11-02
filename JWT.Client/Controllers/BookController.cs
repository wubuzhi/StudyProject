using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Client.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        /// <summary>
        /// AllowAnonymous表示不需要token验证
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<string> Get()
        {
            return new string[] { "ASP", "C#" };
        }

        
        [HttpPost]
        public JsonResult Post()
        {
            return new JsonResult("Create  Book ...");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return Content("好好好好");
        }
    }
}
