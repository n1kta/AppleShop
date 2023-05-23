using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.Response;

namespace AppleShop.Product.API.Features.Product.Queries.GetTopProducts;

public sealed record GetTopProductsQuery : IQuery<IReadOnlyCollection<ProductDetailResponse>>;