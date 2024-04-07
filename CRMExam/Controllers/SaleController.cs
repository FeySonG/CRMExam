

namespace CRMExam.Contracts
{
    [ApiController]
    [Route("api/sale-controller")]
    public class SaleController : ControllerBase
    {
        [HttpGet]
        public Task<IActionResult> GetSales()
        {
            return null;
        }

        [HttpGet("id")]
        public Task<IActionResult> GetMySales()
        {
            return null;
        }

        [HttpPost]
        public Task<IActionResult> MakeDeal()
        {
            return null;
        }
    }
}
