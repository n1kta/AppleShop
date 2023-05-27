using AppleShop.Basket.API.Dtos;
using AppleShop.Basket.API.Enums;
using AutoMapper;

namespace AppleShop.Basket.API.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ColorType, ColorTypeResponse>().ReverseMap();

            CreateMap<ProductDetailResponse, Models.Product>()
                .ForMember(dest => dest.ProductId, src => src.MapFrom(s => s.Id));

            CreateMap<Models.Product, ProductDetailResponse>()
                .ForMember(dest => dest.Id, src => src.MapFrom(s => s.ProductId))
                .ForMember(dest => dest.IsAvailable, src => src.MapFrom(s => s.AvailableStock > 0));
        }
    }
}
