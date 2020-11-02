using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWT.Server.Model;
using JWT.Server.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Server.Controllers
{
    public class TokenController : Controller
    {
        private ITokenHelper tokenHelper = null;
        public TokenController(ITokenHelper _tokenHelper)
        {
            tokenHelper = _tokenHelper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Content("ok");
        }

        /// <summary>
        /// 获取token、以及过期的刷新
        /// </summary>
        /// <param name="code"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(string code, string pwd)
        {
            User user = TemporaryData.TemporaryData.GetUser(code);
            if (null != user && user.Password.Equals(pwd))
            {
                return Ok(tokenHelper.CreateToken(user));
            }
            return BadRequest();
        }

        /// <summary>
        /// 使用过期的token值去验证
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public IActionResult Post()
        {
            return Ok(tokenHelper.RefreshToken(Request.HttpContext.User));
        }
    }
}