using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.Response;

namespace AppleShop.Product.API.Features.CatalogFeatures.Queries.GetAllCategoriesWithProducts;

public sealed record GetAllCategoriesWithProductsQuery() : IQuery<IReadOnlyCollection<CategoryWithProductsResponse>>;