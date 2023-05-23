using AppleShop.Product.API.Abstractions.Messaging;

namespace AppleShop.Product.API.Features.Product.Commands.DeleteProduct;

public sealed record DeleteProductCommand(Guid Id) : ICommand<Guid>;