using AutoMapper;
using Eshop.Application.Configuration.Commands;
using Eshop.Domain.Orders;
using Eshop.Domain.SeedWork;

namespace Eshop.Application.Orders.CustomerOrder.Commands
{
    public class AddOrderCommandHandler : ICommandHandler<AddOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductPriceDataApi _productPriceDataApi;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddOrderCommandHandler(
            IOrderRepository orderRepository, 
            IProductPriceDataApi productPriceDataApi, 
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _productPriceDataApi = productPriceDataApi ?? throw new ArgumentNullException(nameof(productPriceDataApi));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Guid> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {         
            var productsData = await _productPriceDataApi.Get();

            var order = Order.Create(
                request.CustomerId, 
                request.Products.Select(_mapper.Map<OrderProductData>).ToList(), 
                productsData);

            _orderRepository.Add(order);

            await _unitOfWork.CommitAsync(cancellationToken);

            return order.Id;
        }
    }
}
