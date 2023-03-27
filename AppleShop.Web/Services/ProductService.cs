using AppleShop.Web.Infrastructure;
using AppleShop.Web.Services.ModelRequests.Product;
using AppleShop.Web.Services.ModelResponse;
using AppleShop.Web.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

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
        var uri = API.Product.GetAll(_remoteServiceBaseUrl);

        var responseString = await _httpClient.GetStringAsync(uri);

        var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<Product>>>(responseString);

        if (apiResponse == null && (apiResponse != null && !apiResponse.Succeeded))
            return Enumerable.Empty<Product>();

        var products = apiResponse.Data;

        return products;
    }

    public async Task<Product?> GetById(Guid id)
    {
        var uri = API.Product.GetById(_remoteServiceBaseUrl, id);

        var responseString = await _httpClient.GetStringAsync(uri);

        var apiResponse = JsonConvert.DeserializeObject<ApiResponse<Product>>(responseString);

        if (apiResponse == null && (apiResponse != null && !apiResponse.Succeeded))
            return null;

        var product = apiResponse.Data;

        return product;
    }

    public async Task<Guid> Create(CreateProductRequest request)
    {
        var uri = API.Product.Create(_remoteServiceBaseUrl);

        var body = JsonConvert.SerializeObject(request);

        var responseString = await _httpClient.PostAsJsonAsync(uri, body);
        var content = await responseString.Content.ReadAsStringAsync();

        var apiResponse = JsonConvert.DeserializeObject<ApiResponse<Guid>>(content);

        if (apiResponse == null && (apiResponse != null && !apiResponse.Succeeded))
            return Guid.Empty;

        var productId = apiResponse.Data;

        return productId;
    }

    public async Task<Guid> Delete(Guid id)
    {
        var uri = API.Product.Delete(_remoteServiceBaseUrl, id);

        var responseString = await _httpClient.DeleteAsync(uri);
        var content = await responseString.Content.ReadAsStringAsync();

        var apiResponse = JsonConvert.DeserializeObject<ApiResponse<Guid>>(content);

        if (apiResponse == null && (apiResponse != null && !apiResponse.Succeeded))
            return Guid.Empty;

        var productId = apiResponse.Data;

        return productId;
    }

    public async Task<Guid> Update(Guid id, UpdateProductRequest request)
    {
        var uri = API.Product.Update(_remoteServiceBaseUrl, id);

        var body = JsonConvert.SerializeObject(request);

        var responseString = await _httpClient.PutAsJsonAsync(uri, body);
        var content = await responseString.Content.ReadAsStringAsync();

        var apiResponse = JsonConvert.DeserializeObject<ApiResponse<Guid>>(content);

        if (apiResponse == null && (apiResponse != null && !apiResponse.Succeeded))
            return Guid.Empty;

        var productId = apiResponse.Data;

        return productId;
    }
}