using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Products
{
    public class ProductPriceData : ValueObject
    {
        public ProductPriceData(Guid productId, decimal unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }

        public Guid ProductId { get; }

        public decimal UnitPrice { get; set; }
    }
}
