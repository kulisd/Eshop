using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Products;

public class ProductPriceData(Guid productId, decimal unitPrice) : ValueObject
{
    public Guid ProductId { get; } = productId;

    public decimal UnitPrice { get; set; } = unitPrice;
}