using AppleShop.Web.Extensions;
using AppleShop.Web.Infrastructure;
using AppleShop.Web.Services.ModelResponse;
using Microsoft.Extensions.Options;

namespace AppleShop.Web.Services;

public class CategoryService : ICategoryService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly HttpClient _httpClient;

    private readonly string _remoteServiceBaseUrl;

    public CategoryService(HttpClient httpClient, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;

        _remoteServiceBaseUrl = $"{_settings.Value.ProductUrl}/api/v1";
    }

    public async Task<IEnumerable<CatalogWithProductsResponse>> GetAll()
    {
        var url = API.Category.GetAllWithProducts(_remoteServiceBaseUrl);
        var response = await _httpClient.GetRequestAsync<ApiResponse<List<CatalogWithProductsResponse>>,
            List<CatalogWithProductsResponse>>(url);

        return response is null ? Enumerable.Empty<CatalogWithProductsResponse>() : response;
    }
}