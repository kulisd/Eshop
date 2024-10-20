namespace Eshop.Contracts.Shared;

public class ProductDto
{
    public Guid Id { get; private set; }

    public int Quantity { get; private set; }

    private ProductDto()
    {

    }

    public ProductDto(Guid id, int quantity)
    {
        Id = id;
        Quantity = quantity;
    }
}