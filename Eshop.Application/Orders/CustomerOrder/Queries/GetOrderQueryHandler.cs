using AutoMapper;
using Eshop.Application.Configuration.Queries;
using Eshop.Contracts.Shared;
using Eshop.Domain.Orders;

namespace Eshop.Application.Orders.CustomerOrder.Queries;

public class GetOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    : IQueryHandler<GetOrderQuery, OrderDto>
{
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    private readonly IOrderRepository _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));

    public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);
        return _mapper.Map<OrderDto>(order);
    }
}