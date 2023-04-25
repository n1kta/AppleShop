namespace AppleShop.Web.Services.ModelResponse;

public sealed record CatalogWithProductsResponse(Guid Id,
    string Name,
    IReadOnlyCollection<string> ProductName);