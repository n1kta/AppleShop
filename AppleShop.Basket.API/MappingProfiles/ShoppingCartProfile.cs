using AppleShop.Basket.API.Dtos;
using AppleShop.Basket.API.Models;
using AutoMapper;

namespace AppleShop.Basket.API.MappingProfiles
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
            CreateMap<CartDetail, CartDetailDto>().ReverseMap();
            CreateMap<Cart, CartDto>().ReverseMap();
        }
    }
}
