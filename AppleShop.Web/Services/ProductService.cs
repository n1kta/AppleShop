using AppleShop.Web.Extensions;
using AppleShop.Web.Infrastructure;
using AppleShop.Web.Services.ModelRequests.Product;
using AppleShop.Web.Services.ModelResponse;
using AppleShop.Web.Models;
using Microsoft.Extensions.Options;

namespace AppleShop.Web.Services;

public class ProductService : IProductService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly HttpClient _httpClient;

    private readonly string _remoteServiceBaseUrl;

    public ProductService(HttpClient httpClient, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;

        _remoteServiceBaseUrl = $"{_settings.Value.ProductUrl}/api/v1/product";
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        var url = API.Product.GetAll(_remoteServiceBaseUrl);
        var response = await _httpClient.GetRequestAsync<ApiResponse<List<Product>?>, List<Product>?>(url);

        return response is null ? Enumerable.Empty<Product>() : response;
    }

    public async Task<Product?> GetById(Guid id)
    {
        var url = API.Product.GetById(_remoteServiceBaseUrl, id);
        var response = await _httpClient.GetRequestAsync<ApiResponse<Product?>, Product?>(url);

        return response;
    }

    public async Task<Guid> Create(CreateProductRequest request)
    {
        var url = API.Product.Create(_remoteServiceBaseUrl);
        var response = await _httpClient.PostRequestAsync<ApiResponse<Guid?>, CreateProductRequest, Guid?>(url, request);

        return response is null ? Guid.Empty : (Guid) response;
    }

    public async Task<Guid> Delete(Guid id)
    {
        var url = API.Product.Delete(_remoteServiceBaseUrl, id);
        var response = await _httpClient.DeleteRequestAsync<ApiResponse<Guid?>, Guid?>(url);

        return response is null ? Guid.Empty : (Guid)response;
    }

    public async Task<Guid> Update(Guid id, UpdateProductRequest request)
    {
        var url = API.Product.Update(_remoteServiceBaseUrl, id);
        var response = await _httpClient.PostRequestAsync<ApiResponse<Guid?>, UpdateProductRequest, Guid?>(url, request);

        return response is null ? Guid.Empty : (Guid)response;
    }
}