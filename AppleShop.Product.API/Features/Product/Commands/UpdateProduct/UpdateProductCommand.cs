using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.Enums;

namespace AppleShop.Product.API.Features.Product.Commands.UpdateProduct;

public sealed record UpdateProductCommand(Guid Id,
    string Name,
    string Description,
    ColorType Color,
    int Memory,
    int AvailableStock,
    string? PictureUri,
    double Price,
    string CategoryName) : ICommand<Guid>;