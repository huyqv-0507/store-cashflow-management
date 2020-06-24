using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.EditModel;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace store_cash_flow_management.Controllers
{
    [Authorize]
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
            if (stores == null) return Content("Không có cửa hàng nào");
            return Ok(stores);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult getStore(int id)
        {
            var store = _service.getStoreById(id);
            if (store == null) return Content("Id sai hoặc cửa hàng không tồn tại");
            return Ok(store);
        }
        [HttpPost]
        public IActionResult createStore(StoreUpdateModel store)
        {
            if(store != null)
            {
                if (_service.createStore(store)) return Ok("Tạo cửa hàng thành công.");
            }
            return Content("Tạo cửa hàng thất bại.");
        }
        [HttpPut]
        public IActionResult updateStore(StoreUpdateModel store)
        {
            if (store != null)
            {
                if (_service.updateStore(store)) return Ok("Cập nhật cửa hàng thành công.");
            }
            return Content("Cập nhật cửa hàng thất bại.");
        }
        [HttpDelete]
        public IActionResult deleteStore(int id)
        {
            if (id != null)
            {
                if (_service.deleteStore(id)) return Ok("Xóa cửa hàng thành công.");
            }
            return Content("Xóa cửa hàng thất bại.");
        }
    }
}