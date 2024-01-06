using Eshop.Domain.Products;

namespace Eshop.Domain.Orders
{
    public interface IProductPriceDataApi
    {
        Task<List<ProductPriceData>> Get();
    }
}
