

using Microsoft.AspNetCore.Authorization;

namespace CRMExam.Contracts
{
    [ApiController]
    [Route("api/sale-controller")]
    public class SaleController(SaleService service) : ControllerBase
    {
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetSales()
        {
            var sales = await service.GetAll();

            return Ok(sales);
        }
        [Authorize(Roles = "saller")]
        [HttpGet("MySales")]
        public async Task<IActionResult> GetMySales()
        {
            var mySales = await service.MySales();
            if(mySales == null) return BadRequest();

            return Ok(mySales);
        }

        [Authorize(Roles = "saller")]
        [HttpPost("{id}")]
        public async Task<IActionResult> MakeDeal(Guid leadId)
        {
            var sale = await service.MakeDeal(leadId);
            if(sale == null) return BadRequest();
            return Ok(sale);


            
        }
    }
}
