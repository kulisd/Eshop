using Eshop.Contracts;
using Eshop.Contracts.Shared;
using Swashbuckle.AspNetCore.Filters;

namespace Eshop.API.Examples;

public class CustomerOrderRequestExample : IExamplesProvider<CustomerOrderRequest>
{
    public CustomerOrderRequest GetExamples()
    {
        return new CustomerOrderRequest
        (
            [
                new ProductDto(Guid.Parse("514f6265-a9b8-46da-a31d-50f4f4c20911"), 2),
                new ProductDto(Guid.Parse("514f6265-a9b8-46da-a31d-50f4f4c20912"), 1)
            ]
        );
    }
}