using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Orders
{
    public class OrderProduct : ValueObject
    {
        public Guid Id { get; private set; }

        public int Quantity { get; private set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalCost
        {
            get { return Quantity * UnitPrice; }
        }

        private OrderProduct()
        {

        }

        private OrderProduct(Guid productId, int quantity, decimal unitPrice)
        {
            Id = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public static OrderProduct Create(Guid productId, int quantity, decimal unitPrice)
        {
            return new OrderProduct(productId, quantity, unitPrice);
        }
    }
}
