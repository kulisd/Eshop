namespace Eshop.Infrastructure.Exceptions;

/// <summary>
/// Exception thrown when an order with the specified ID does not exist.
/// </summary>
public class OrderNotExistsException(Guid id) : Exception($"Order with ID '{id}' does not exist.")
{
    public Guid Id { get; } = id;
}