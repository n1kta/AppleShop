using AppleShop.Web.Services.ModelResponse;

namespace AppleShop.Web.Services.ModelRequests.Product;

public sealed record UpdateProductRequest(Guid Id,
    string Name,
    string Description,
    ColorTypeResponse Color,
    int Memory,
    int AvailableStock,
    string? PictureUri,
    double Price,
    string CategoryName);