using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.Response;

namespace AppleShop.Product.API.Features.CatalogFeatures.Queries.GetAllProducts;

public sealed record GetAllProductsQuery() : IQuery<List<ProductResponse>>;