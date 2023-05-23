namespace AppleShop.Product.API.Response;

public sealed record CategoryWithProductsResponse(Guid Id,
    string Name,
    IReadOnlyCollection<ProductResponse> Product);