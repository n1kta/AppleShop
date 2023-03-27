using AppleShop.Product.API.Features.CatalogFeatures.Commands.CreateProduct;
using AppleShop.Product.API.Features.CatalogFeatures.Commands.UpdateProduct;
using AppleShop.Product.API.Response;
using AutoMapper;

namespace AppleShop.Product.API.MappingProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        // Model -> Dto
        CreateMap<Models.Product, ProductResponse>();

        // Dto -> Model
        CreateMap<ProductResponse, Models.Product>();
        CreateMap<CreateProductCommand, Models.Product>();
        CreateMap<UpdateProductCommand, Models.Product>();
    }
}