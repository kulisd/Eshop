using Eshop.Application.Shared;

namespace Eshop.API.Controllers
{
    public class CustomerOrderRequest
    {
        public List<ProductDto> Products { get; set; }

        public CustomerOrderRequest(List<ProductDto> products)
        {
            Products = products ?? throw new ArgumentNullException(nameof(products));
        }
    }
}
