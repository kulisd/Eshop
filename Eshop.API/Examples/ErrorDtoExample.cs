using Eshop.Contracts.Shared;
using Swashbuckle.AspNetCore.Filters;

namespace Eshop.API.Examples;

public class ErrorDtoExample : IExamplesProvider<ErrorDto>
{
    public ErrorDto GetExamples()
    {
        return new ErrorDto("Error message", "Detailed error message");
    }
}