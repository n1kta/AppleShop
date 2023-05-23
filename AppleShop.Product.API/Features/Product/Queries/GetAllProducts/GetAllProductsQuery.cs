using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.Response;

namespace AppleShop.Product.API.Features.Product.Queries.GetAllProducts;

public sealed record GetAllProductsQuery(Guid? CategoryId, int PageNumber = 1, int PageSize = 10)
    : IPagedQuery<IReadOnlyCollection<ProductDetailResponse>>;