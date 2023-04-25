using AppleShop.Web.Services.ModelResponse;

namespace AppleShop.Web.Services;

public interface ICategoryService
{
    Task<IEnumerable<CatalogWithProductsResponse>> GetAll();
}