using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace store_cash_flow_management.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountsController(IAccountService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult loginAccount(AccountLoginModel model)
        {
            var token = _service.loginAccount(model);
            if (token != null)
            {
                return Ok(token);
            }
            return Content("Tài khoản hoặc mật khẩu sai");
        }
    }
}
