using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Customers;

public class Customer : Entity, IAggregateRoot
{
    public string Name { get; }    
        
    public static Customer Create(Guid id, string name)
    {
        return new(id, name);
    }

    private Customer(Guid id, string name) : base(Guid.NewGuid())
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}