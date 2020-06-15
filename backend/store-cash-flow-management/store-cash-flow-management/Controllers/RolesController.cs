using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace store_cash_flow_management.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public IActionResult getRoles()
        {
            var roles = _roleService.getRoles();
            if (roles == null) return BadRequest();
            return Ok(roles);
        }
    }
}
