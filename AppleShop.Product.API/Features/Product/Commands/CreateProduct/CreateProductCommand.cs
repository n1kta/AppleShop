using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.Enums;

namespace AppleShop.Product.API.Features.Product.Commands.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    string Description,
    ColorType Color,
    int Memory,
    int AvailableStock,
    string PictureUri,
    double Price,
    Guid CategoryId,
    string? Series) : ICommand<Guid>;