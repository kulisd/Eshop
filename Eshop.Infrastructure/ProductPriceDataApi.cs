using Eshop.Domain.Orders;
using Eshop.Domain.Products;

namespace Eshop.Infrastructure
{
    internal class ProductPriceDataApi : IProductPriceDataApi
    {
        public Task<List<ProductPriceData>> Get()
        {
            List<ProductPriceData> productPriceDatas = new List<ProductPriceData>()
            {
                new ProductPriceData(Guid.Parse("514f6265-a9b8-46da-a31d-50f4f4c20911"), 10),
                new ProductPriceData(Guid.Parse("514f6265-a9b8-46da-a31d-50f4f4c20912"), 20),
                new ProductPriceData(Guid.Parse("514f6265-a9b8-46da-a31d-50f4f4c20913"), 30),
                new ProductPriceData(Guid.Parse("514f6265-a9b8-46da-a31d-50f4f4c20914"), 40),
            };

            return Task.FromResult(productPriceDatas);
        }
    }
}
