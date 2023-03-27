using AppleShop.Product.API.Abstractions.Messaging;

namespace AppleShop.Product.API.Features.CatalogFeatures.Commands.DeleteProductById;

public sealed record DeleteProductByIdCommand(Guid Id) : ICommand<Guid>;