using Eshop.Application.Configuration.Commands;
using Eshop.Application.Shared;

namespace Eshop.Application.Orders.CustomerOrder.Commands
{
    public class AddOrderCommand : CommandBase<Guid>
    {
        public Guid CustomerId { get; }

        public List<ProductDto> Products { get; }

        public AddOrderCommand(
            Guid customerId,
            List<ProductDto> products)
        {
            CustomerId = customerId;
            Products = products ?? throw new ArgumentNullException(nameof(products));
        }
    }
}
