using Common.Models;

namespace Monolith.ShoppingCartApi.Coordinators
{
    public class ObservableCheckoutService : ICheckoutService
    {       
        private readonly IObserver<QueueItem> _checkoutStream;

        public ObservableCheckoutService(IObserver<QueueItem> checkoutStream)
        {
            _checkoutStream = checkoutStream;
        }

        public Task<CheckoutResponse> AddCheckoutRequestAsync(CheckoutRequest request)
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

            _checkoutStream.OnNext(queueItem);

            return Task.FromResult(response);
        }
    }        
}