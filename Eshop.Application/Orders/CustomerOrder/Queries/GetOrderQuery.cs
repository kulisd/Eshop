using Eshop.Application.Configuration.Queries;
using Eshop.Application.Shared;

namespace Eshop.Application.Orders.CustomerOrder.Queries
{
    public class GetOrderQuery : IQuery<OrderDto>
    {
        public Guid OrderId { get; }

        public GetOrderQuery(
            Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
