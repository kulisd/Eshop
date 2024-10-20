using Eshop.Contracts.Shared;

namespace Eshop.Contracts;

public class CustomerOrderRequest(List<ProductDto> products)
{
    public List<ProductDto> Products { get; } = products is null 
        ? throw new ArgumentNullException(nameof(products))
        : products.Count == 0
            ? throw new ArgumentException("Products list cannot be empty.", nameof(products))
            : products;
}