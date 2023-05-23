using AppleShop.Web.Services.ModelRequests.Product;
using AppleShop.Web.Models;
using AppleShop.Web.Services.Wrappers;

namespace AppleShop.Web.Services;

public interface IProductService
{
    Task<PagedResponse<List<ProductDetailResponse>>> GetAll(Guid? categoryId, int pageNumber = 1, int pageSize = 10);

    Task<ProductDetailResponse?> GetById(Guid id);

    Task<Guid> Create(CreateProductRequest request);

    Task<Guid> Delete(Guid id);

    Task<Guid> Update(Guid id, UpdateProductRequest request);

    Task<Dictionary<string, int>> GetDashboardAmount();

    Task<IEnumerable<ProductDetailResponse>> GetTopProducts();
}