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
    public class CashTransactionsController : ControllerBase
    {
        private readonly ICashTransactionService _service;

        public CashTransactionsController()
        {
        }

        public CashTransactionsController(ICashTransactionService service)
        {
            _service = service;
        }

        [HttpGet("{typeId}")]
        public IActionResult getTransactionsByType(int typeId)
        {
            var listTransaction = _service.getTransactionWithTransactionType(typeId);
            if(listTransaction.Count != 0)
            {
                return Ok(listTransaction);
            }
            return Content("Không có giao dịch nào .");
        }
    }
}