using AppleShop.Basket.API.Dtos;
using AutoMapper;

namespace AppleShop.Basket.API.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Models.Product, ProductDto>().ReverseMap();
        }
    }
}
