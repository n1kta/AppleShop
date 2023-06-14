using AppleShop.Web.Extensions;
using AppleShop.Web.Infrastructure;
using AppleShop.Web.Services.ModelResponse;
using Microsoft.Extensions.Options;

namespace AppleShop.Web.Services;

public class OrderService : IOrderService
{
    private readonly IOptions<AppSettings> _settings;

    private readonly HttpClient _httpClient;

    private readonly string _remoteServiceBaseUrl;

    public OrderService(IOptions<AppSettings> settings, HttpClient httpClient)
    {
        _httpClient = httpClient;
        _settings = settings;

        _remoteServiceBaseUrl = $"{_settings.Value.OrderUrl}/api/v1";
    }

    public async Task<IEnumerable<OrderResponse>> GetAll()
    {
        var url = API.Order.GetAll(_remoteServiceBaseUrl);

        var response = await _httpClient.GetRequestAsync<ApiResponse<IEnumerable<OrderResponse>>, IEnumerable<OrderResponse>>(url);

        return response;
    }
}