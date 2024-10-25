namespace Eshop.Contracts.Shared;

public class ErrorDto(string error, string details)
{
    /// <summary>
    /// Gets the error message.
    /// </summary>
    public string Error { get; init; } = error;

    /// <summary>
    /// Gets the detailed description of the error.
    /// </summary>
    public string Details { get; init; } = details;
}