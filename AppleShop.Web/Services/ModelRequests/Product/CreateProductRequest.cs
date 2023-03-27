using AppleShop.Web.Services.ModelDTOs;

namespace AppleShop.Web.Services.ModelRequests.Product;

public sealed record CreateProductRequest(string Name,
        string Description,
        ColorType Color,
        int Memory,
        int AvailableStock,
        string PictureUri,
        double Price,
        Guid CategoryId);