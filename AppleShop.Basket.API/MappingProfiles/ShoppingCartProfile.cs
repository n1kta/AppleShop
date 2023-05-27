using AppleShop.Basket.API.Dtos;
using AppleShop.Basket.API.Models;
using AutoMapper;

namespace AppleShop.Basket.API.MappingProfiles
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<Cart, CartDto>();
            CreateMap<CartHeader, CartHeaderDto>();
            CreateMap<CartDetail, CartDetailDto>()
                .ForMember(dest => dest.Product, src => src.MapFrom(s => s.Product));

            CreateMap<CartDto, Cart>();
            CreateMap<CartHeaderDto, CartHeader>();
            CreateMap<CartDetailDto, CartDetail>();
        }
    }
}
