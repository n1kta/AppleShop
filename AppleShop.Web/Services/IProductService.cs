using AppleShop.Web.Services.ModelRequests.Product;
using AppleShop.Web.ViewModels;

namespace AppleShop.Web.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAll();

    Task<Product?> GetById(Guid id);

    Task<Guid> Create(CreateProductRequest request);

    Task<Guid> Delete(Guid id);

    Task<Guid> Update(Guid id, UpdateProductRequest request);
}