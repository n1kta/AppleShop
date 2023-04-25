using AppleShop.Web.Services.ModelRequests.Product;
using AppleShop.Web.Models;

namespace AppleShop.Web.Services;

public interface IProductService
{
    Task<IEnumerable<ProductResponse>> GetAll();

    Task<ProductResponse?> GetById(Guid id);

    Task<Guid> Create(CreateProductRequest request);

    Task<Guid> Delete(Guid id);

    Task<Guid> Update(Guid id, UpdateProductRequest request);
}