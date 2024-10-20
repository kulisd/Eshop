using Eshop.Domain.Products;

namespace Eshop.Application.Orders;

public interface IProductPriceDataApi
{
    Task<List<ProductPriceData>> Get();
}