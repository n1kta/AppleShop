using AppleShop.Web.Services.Wrappers;

namespace AppleShop.Web.Models;

public class ProductListViewModel
{
    public PagedResponse<List<ProductDetailResponse>> Products { get; set; }
}