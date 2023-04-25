using AppleShop.Web.Services.ModelResponse;

namespace AppleShop.Web.Models;

public sealed record ProductResponse(string Name,
    string Description,
    ColorTypeResponse Color,
    int Memory,
    bool IsAvailable,
    string? PictureUri,
    double Price,
    string CategoryName);