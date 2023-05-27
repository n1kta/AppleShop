using AppleShop.Product.API.Features.Product.Commands.CreateProduct;
using AppleShop.Product.API.Features.Product.Commands.UpdateProduct;
using AppleShop.Product.API.Response;
using AutoMapper;

namespace AppleShop.Product.API.MappingProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        // Model -> Dto
        CreateMap<Models.Product, ProductDetailResponse>()
            .ForMember(dest => dest.CategoryName, src => src.MapFrom(s => s.Category.Name))
            .ForMember(dest => dest.Id, src => src.MapFrom(s => s.Id));

        // Dto -> Model
        CreateMap<ProductDetailResponse, Models.Product>();
        CreateMap<CreateProductCommand, Models.Product>();
        CreateMap<UpdateProductCommand, Models.Product>();
    }
}