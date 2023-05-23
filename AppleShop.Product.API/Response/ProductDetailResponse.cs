using AppleShop.Product.API.Enums;

namespace AppleShop.Product.API.Response;

public sealed record ProductDetailResponse(Guid Id,
    string Name,
    string Series,
    string Description,
    ColorType Color,
    int Memory,
    bool IsAvailable,
    string? PictureUri,
    double Price,
    string CategoryName);