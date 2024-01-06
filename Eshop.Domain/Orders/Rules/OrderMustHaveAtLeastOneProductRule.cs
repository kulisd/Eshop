using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Orders.Rules
{
    public class OrderMustHaveAtLeastOneProductRule : IBusinessRule
    {
        private readonly List<OrderProduct> _orderProducts;

        public OrderMustHaveAtLeastOneProductRule(List<OrderProduct> orderProducts)
        {
            _orderProducts = orderProducts;
        }

        public bool IsBroken() => !_orderProducts.Any();

        public string Message => "Order must have at least one product";
    }
}