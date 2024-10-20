namespace Eshop.Contracts.Shared;

public class OrderDto
{
    public Guid Id { get; }

    public List<ProductDto> Products { get; }

    private OrderDto()
    {
        Products = new List<ProductDto>();
    }

    public OrderDto(Guid id, List<ProductDto> products)
    {
        Id = id;
        Products = products ?? throw new ArgumentNullException(nameof(products));
    }
}