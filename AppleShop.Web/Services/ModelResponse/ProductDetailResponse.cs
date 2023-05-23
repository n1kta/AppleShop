using AppleShop.Web.Services.ModelResponse;

namespace AppleShop.Web.Models;

public sealed record ProductDetailResponse(Guid Id,
    string Name,
    string Series,
    string Description,
    ColorTypeResponse Color,
    int Memory,
    bool IsAvailable,
    string? PictureUri,
    double Price,
    string CategoryName);