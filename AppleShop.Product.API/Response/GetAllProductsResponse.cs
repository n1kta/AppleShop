using AppleShop.Product.API.Wrappers;

namespace AppleShop.Product.API.Response;

public class GetAllProductsResponse
{
    public int? Color { get; set; }

    public int? MinPrice { get; set; }

    public int? MaxPrice { get; set; }

    public int? Memory { get; set; }

    public PagedResponse<IReadOnlyCollection<ProductDetailResponse>> Products { get; set; }
}