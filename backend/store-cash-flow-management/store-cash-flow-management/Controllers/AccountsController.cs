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
        [HttpGet]
        public IActionResult loginAccount(AccountLoginModel model)
        {
            var token = _service.loginAccount(model);
            if (token != null)
            {
                return Ok(token);
            }
            return Unauthorized();
        }

        [HttpPost]
        public IActionResult createAccount(bool isAdmin, CreateAccountModel account)
        {
            if (isAdmin)
            {
                if (_service.createAccount(account))
                {
                    return Ok("Tạo tài khoản thành công");
                }
            }
            else
            {
                return Content("Bạn không phải admin");
            }


            return Content("Tạo tài khoản thất bại ");
        }

        [HttpDelete]
        public IActionResult deleteAccount(bool isAdmin, long idAccount)
        {
            if (isAdmin)
            {
                if (_service.deleteAccount(idAccount)) return Ok("Delete thành công");
                else return Content("Delete Thất bại");
            }
            return NoContent();
        }

        [HttpPut]
        public IActionResult updateAccount(bool isAdmin,long idAccount,AccountUpdateModel account)
        {
            if (isAdmin)
            {
                if (_service.updateAccount(idAccount,account)) return Ok();
            }
            return NotFound();
        }
    }
}
