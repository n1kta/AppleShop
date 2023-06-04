using AppleShop.Web.Extensions;
using AppleShop.Web.Infrastructure;
using AppleShop.Web.Services.ModelRequests.Product;
using AppleShop.Web.Services.ModelResponse;
using AppleShop.Web.Models;
using Microsoft.Extensions.Options;
using AppleShop.Web.Services.Wrappers;

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

        _remoteServiceBaseUrl = $"{_settings.Value.ProductUrl}/api/v1";
    }

    public async Task<PagedResponse<List<ProductDetailResponse>>> GetAll(
        Guid? categoryId,
        int? color = null,
        int? minPrice = null,
        int? maxPrice = null,
        int? memory = null,
        int pageNumber = 1,
        int pageSize = 10)
    {
        var url = API.Product.GetAll(_remoteServiceBaseUrl) + "?";

        if (Guid.Empty != categoryId)
            url += $"id={categoryId}&";

        if (color != null)
            url += $"color={color}&";

        if (minPrice != null)
            url += $"minPrice={minPrice}&";

        if (maxPrice != null)
            url += $"maxPrice={maxPrice}&";

        if (memory != null)
            url += $"memory={memory}&";

        url += $"pageNumber={pageNumber}&pageSize={pageSize}";

        var response = await _httpClient.GetPagedRequestAsync<List<ProductDetailResponse>>(url);

        return response is null 
            ? new PagedResponse<List<ProductDetailResponse>>(Guid.Empty,
                Enumerable.Empty<ProductDetailResponse>().ToList(),
                pageNumber,
                pageSize,
                default) : response;
    }

    public async Task<ProductDetailResponse?> GetById(Guid id)
    {
        var url = API.Product.GetById(_remoteServiceBaseUrl, id);
        var response = await _httpClient.GetRequestAsync<ApiResponse<ProductDetailResponse?>, ProductDetailResponse?>(url);

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

    public async Task<Dictionary<string, int>> GetDashboardAmount()
    {
        var url = API.Product.GetDashboardAmount(_remoteServiceBaseUrl);
        var response = await _httpClient.GetRequestAsync<ApiResponse<Dictionary<string, int>>, Dictionary<string, int>>(url);

        return response;
    }

    public async Task<IEnumerable<ProductDetailResponse>> GetTopProducts()
    {
        var url = API.Product.GetTopProducts(_remoteServiceBaseUrl);
        var response = await _httpClient.GetRequestAsync<ApiResponse<List<ProductDetailResponse>?>, List<ProductDetailResponse>?>(url);

        return response is null ? Enumerable.Empty<ProductDetailResponse>() : response;
    }
}