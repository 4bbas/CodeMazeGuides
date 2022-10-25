using Common.Models;

namespace Monolith.ShoppingCartApi.Coordinators
{
    public interface ICheckoutService
    {
        Task<CheckoutResponse> AddCheckoutRequestAsync(CheckoutRequest request);
    }
}
