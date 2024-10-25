using Eshop.Application.Configuration.Commands;
using Eshop.Contracts.Shared;

namespace Eshop.Application.Orders.CustomerOrder.Commands;

public class AddOrderCommand(
    Guid customerId,
    List<ProductDto> products) : CommandBase<Guid>
{
    public Guid CustomerId { get; } = customerId;

    public List<ProductDto> Products { get; } = products ?? throw new ArgumentNullException(nameof(products));
}