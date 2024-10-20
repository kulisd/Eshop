using Eshop.Domain.SeedWork;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Eshop.Domain.Orders;

public class OrderProduct : ValueObject
{
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; private set; }

    public int Quantity { get; private set; }

    public decimal UnitPrice { get; private set; }

    public decimal TotalCost => Quantity * UnitPrice;

    private OrderProduct()
    {

    }

    private OrderProduct(Guid productId, int quantity, decimal unitPrice)
    {
        Id = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public static OrderProduct Create(Guid productId, int quantity, decimal unitPrice)
    {
        return new OrderProduct(productId, quantity, unitPrice);
    }
}