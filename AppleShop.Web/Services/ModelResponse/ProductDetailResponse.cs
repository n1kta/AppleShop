using AppleShop.Web.Services.ModelResponse;

namespace AppleShop.Web.Models;

public sealed record ProductDetailResponse(Guid Id,
    string Name,
    string Series,
    string Description,
    ColorTypeResponse Color,
    int Memory,
    bool IsAvailable,
    int AvailableStock,
    string? PictureUri,
    double Price,
    string CategoryName,
    int Count = 1);