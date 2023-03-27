using AppleShop.Web.Services.ModelDTOs;

namespace AppleShop.Web.ViewModels;

public sealed record Product(string Name,
    string Description,
    ColorType Color,
    int Memory,
    bool IsAvailable,
    string? PictureUri,
    double Price,
    string CategoryName);