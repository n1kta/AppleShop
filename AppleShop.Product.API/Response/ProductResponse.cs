using AppleShop.Product.API.Enums;

namespace AppleShop.Product.API.Response;

public sealed record ProductResponse(string Name,
    string Description,
    ColorType Color,
    int Memory,
    bool IsAvailable,
    string? PictureUri,
    double Price,
    string CategoryName);