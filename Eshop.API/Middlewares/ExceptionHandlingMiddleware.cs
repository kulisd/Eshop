using System.Net;
using System.Text.Json;
using Eshop.Contracts.Shared;
using Eshop.Domain.SeedWork;

namespace Eshop.API.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (BusinessRuleValidationException ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, BusinessRuleValidationException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var response = new ErrorDto(exception.Message, exception.Details);

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}