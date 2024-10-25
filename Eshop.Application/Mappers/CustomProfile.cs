using AutoMapper;
using Eshop.Contracts.Shared;
using Eshop.Domain.Orders;

namespace Eshop.Application.Mappers;

internal class CustomProfile : Profile
{
    public CustomProfile()
    {
        CreateMap<OrderProductData, ProductDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

        CreateMap<ProductDto, OrderProductData>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

        CreateMap<OrderDto, Order>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

        CreateMap<OrderProduct, ProductDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
    }
}