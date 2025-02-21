using CargoPay.Service.IServices;
using CargoPay.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CargoPay.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService) {
        
            _paymentService = paymentService;
           
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Pay(Payment payment)
        {
            var result = await _paymentService.Pay(payment);

            if(result.data== null) {

                return StatusCode(500, new { message = result.Message });
            
            }

            return Ok(result.data);
        }


    }
}
