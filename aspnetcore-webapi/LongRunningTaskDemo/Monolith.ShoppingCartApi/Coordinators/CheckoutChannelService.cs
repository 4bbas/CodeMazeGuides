using Common.Models;
using Monolith.ShoppingCartApi.Services.Interfaces;

namespace Monolith.ShoppingCartApi.Coordinators
{
    public class CheckoutChannelService : ICheckoutService
    {
        private readonly ICheckoutProcessingChannel _checkoutProcessingChannel;

        public CheckoutChannelService(ICheckoutProcessingChannel checkoutProcessingChannel)
        {
            _checkoutProcessingChannel = checkoutProcessingChannel;            
        }

        public async Task<CheckoutResponse> AddCheckoutRequestAsync(CheckoutRequest request)
        {
            var response = new CheckoutResponse
            {
                OrderId = Guid.NewGuid(),
                OrderStatus = OrderStatus.Inprogress,
                Message = "Your order is in progress and you will receive an email with all details once the processing completes."
            };

            var queueItem = new QueueItem
            {
                OrderId = response.OrderId,
                Request = request
            };

            await _checkoutProcessingChannel.AddQueueItemAsync(queueItem);  
            
            return response;
        }
    }
}
