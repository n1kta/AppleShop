using AppleShop.Web.Extensions;
using AppleShop.Web.Infrastructure;
using AppleShop.Web.Services.ModelRequests.Cart;
using AppleShop.Web.Services.ModelResponse;
using Microsoft.Extensions.Options;

namespace AppleShop.Web.Services;

public class CartService : ICartService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly HttpClient _httpClient;

    private readonly string _remoteServiceBaseUrl;

    public CartService(HttpClient httpClient, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;

        _remoteServiceBaseUrl = $"{_settings.Value.BasketUrl}/api/v1";
    }

    public async Task<CartDto?> AddCartAsync(CartDto cartDto, string token)
    {
        var url = API.Basket.AddCart(_remoteServiceBaseUrl);

        var response = await _httpClient.PostRequestAsync<ApiResponse<CartDto?>, CartDto, CartDto?>(url, cartDto);

        return response;
    }

    public Task<T> Checkout<T>(CartHeaderDto dto, string token)
    {
        throw new NotImplementedException();
    }

    public async Task<CartDto?> GetCartByUserIdAsync(string userId, string token)
    {
        var url = API.Basket.GetCart(_remoteServiceBaseUrl, userId);

        var response = await _httpClient.GetRequestAsync<ApiResponse<CartDto?>, CartDto?>(url);

        return response;
    }

    public async Task<bool> RemoveFromCartAsync(int cartId, string token)
    {
        var url = API.Basket.RemoveCart(_remoteServiceBaseUrl, cartId);

        var response = await _httpClient.DeleteRequestAsync<ApiResponse<bool>, bool>(url);

        return response;
    }

    public async Task<CartDto?> UpdateCartAsync(CartDto cartDto, string token)
    {
        var url = API.Basket.UpdateCart(_remoteServiceBaseUrl);
        var response = await _httpClient.PostRequestAsync<ApiResponse<CartDto?>, CartDto, CartDto?>(url, cartDto);

        return response;
    }
}