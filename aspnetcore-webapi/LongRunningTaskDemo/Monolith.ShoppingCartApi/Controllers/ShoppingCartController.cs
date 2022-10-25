using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Monolith.ShoppingCartApi.Coordinators;

namespace Monolith.ShoppingCartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ICheckoutService _checkoutService;

        public ShoppingCartController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpPost("checkout")]
        [ProducesResponseType(typeof(CheckoutResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Checkout(CheckoutRequest request) 
            => Ok(await _checkoutService.AddCheckoutRequestAsync(request));
    }
}