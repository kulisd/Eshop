using Eshop.Domain.Orders.Events;
using Eshop.Domain.Orders.Rules;
using Eshop.Domain.Products;
using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Orders
{
    public class Order : Entity
    {
        public Guid Id { get; }

        public Guid CustomerId { get; }

        public List<OrderProduct> Products { get; }

        private Order(Guid customerId, List<OrderProduct> orderProducts)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            Products = orderProducts ?? throw new ArgumentNullException(nameof(orderProducts));

            AddDomainEvent(new OrderAddedEvent(Id, customerId));
        }

        public static Order Create(
            Guid customerId,
            List<OrderProductData> orderProductsData,
            List<ProductPriceData> allProductPriceDatas)
        {
            List<OrderProduct> orderProducts = new();

            foreach (var orderProductData in orderProductsData)
            {
                var productPriceData = allProductPriceDatas.First(x => x.ProductId == orderProductData.ProductId);

                var orderProduct = OrderProduct.Create(orderProductData.ProductId, orderProductData.Quantity, productPriceData.UnitPrice);

                orderProducts.Add(orderProduct);
            }

            CheckRule(new OrderMustHaveAtLeastOneProductRule(orderProducts));

            return new Order(customerId, orderProducts);
        }
    }
}
