namespace Eshop.Domain.Orders;

public class OrderProductData
{
    private OrderProductData()
    {

    }

    public OrderProductData(Guid productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }

    public Guid ProductId { get; private set; }

    public int Quantity { get; private set; }
}