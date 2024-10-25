using Eshop.Application.Orders;
using Eshop.Domain.Products;

namespace Eshop.Infrastructure;

internal class ProductPriceDataApi : IProductPriceDataApi
{
    public Task<List<ProductPriceData>> Get()
    {
        var productPriceData = new List<ProductPriceData>()
        {
            new(Guid.Parse("514f6265-a9b8-46da-a31d-50f4f4c20911"), 10),
            new(Guid.Parse("514f6265-a9b8-46da-a31d-50f4f4c20912"), 20),
            new(Guid.Parse("514f6265-a9b8-46da-a31d-50f4f4c20913"), 30),
            new(Guid.Parse("514f6265-a9b8-46da-a31d-50f4f4c20914"), 40),
        };

        return Task.FromResult(productPriceData);
    }
}