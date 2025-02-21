using CargoPay.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CargoPay.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class CardController : ControllerBase
    {

        private readonly ICardService _card;
        public CardController(ICardService card)
        {
            _card = card;
        }

        [HttpPost]
        [Route("/CreateCard")]
        [Authorize]
        public async Task<IActionResult> CreateCard(double creditLimit)
        {
            var result = await _card.CreateCard(creditLimit);
            if (result.data == null)
            {
                return StatusCode(500 , new { message = result.Message });
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("/GetBalance")]
        [Authorize]
        public async Task<IActionResult> getbalance(long cardNumber)
        {
            var result = await _card.GetBalance(cardNumber);
            if (result.Balance == null)
            {
                return NotFound(new { message = result.Message });
            }
            return Ok(result);
        }
    }
}
