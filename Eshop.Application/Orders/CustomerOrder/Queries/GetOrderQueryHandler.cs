using AutoMapper;
using Eshop.Application.Configuration.Queries;
using Eshop.Application.Shared;
using Eshop.Domain.Orders;

namespace Eshop.Application.Orders.CustomerOrder.Queries
{
    public class GetOrderQueryHandler : IQueryHandler<GetOrderQuery, OrderDto>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);
            return _mapper.Map<OrderDto>(order);
        }
    }
}
