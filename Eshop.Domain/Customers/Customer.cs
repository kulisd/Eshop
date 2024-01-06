using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Shared
{
    public class Customer : Entity, IAggregateRoot
    {
        public Guid Id { get; } 

        public string Name { get; }    
        
        public static Customer Create(Guid id, string name)
        {
            return new(id, name);
        }

        private Customer(Guid id, string name)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
