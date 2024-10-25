using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Orders.Rules;

public class OrderMustHaveAtLeastOneProductRule(IReadOnlyCollection<OrderProduct> orderProducts) : IBusinessRule
{
    public bool IsBroken() => orderProducts.Count == 0;

    public string Message => "Order must have at least one product";
}