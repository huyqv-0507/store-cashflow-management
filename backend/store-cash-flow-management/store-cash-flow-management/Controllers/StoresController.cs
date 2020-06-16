using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace store_cash_flow_management.Controllers
{   
   
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoreService _service;
        public StoresController(IStoreService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult getStores()
        {
            var stores = _service.getStores();
            if (stores == null) return Content("Can't get all store");
            return Ok(stores);
        }
        [HttpGet("{id}")]
        public IActionResult getStore(int id)
        {
            var store = _service.getStoreById(id);
            if (store == null) return Content("Not have store");
            return Ok(store);
        }
    //    [HttpGet]
    //    public IActionResult getStoresByPage([FromQuery]int? pageNumber, [FromQuery] int? pageSize)
    //    {
    //        var store = _service.getStoreByPage(pageNumber,pageSize);
    //        if (store == null) return Content("Not have store");
    //        return Ok(store);
    //    }
    //}
}