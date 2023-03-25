using AppleShop.Product.API.Features.CatalogFeatures.Commands.CreateProduct;
using AppleShop.Product.API.Response;
using AutoMapper;

namespace AppleShop.Product.API.MappingProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        // Model -> Dto
        CreateMap<Models.Product, ProductResponse>()
            .ReverseMap();

        // Dto -> Model
        CreateMap<CreateProductCommand, Models.Product>();
    }
}