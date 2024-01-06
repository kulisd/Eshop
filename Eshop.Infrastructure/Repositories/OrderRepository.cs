using Eshop.Domain.Orders;
using Eshop.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Eshop.Infrastructure.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly OrdersContext _context;
        private readonly IEntityTracker _entityTracker;

        public OrderRepository(OrdersContext context, IEntityTracker entityTracker)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entityTracker = entityTracker ?? throw new ArgumentNullException(nameof(entityTracker));
        }

        public void Add(Order order)
        {
            _entityTracker.TrackEntity(order);
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            var order = await _context.Orders.Find(c => c.Id == id).FirstAsync();

            if(order == null)
            {
                throw new OrderNotExistsException(id);
            }

            _entityTracker.TrackEntity(order);

            return order;
        }
    }
}
