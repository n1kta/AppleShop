using AppleShop.Web.Extensions;
using AppleShop.Web.Infrastructure;
using AppleShop.Web.Services.ModelResponse;
using Microsoft.Extensions.Options;

namespace AppleShop.Web.Services;

public class UserService : IUserService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly HttpClient _httpClient;

    private readonly string _remoteServiceBaseUrl;

    public UserService(HttpClient httpClient, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;

        _remoteServiceBaseUrl = $"{_settings.Value.IdentityUrl}/api/v1";
    }

    public async Task<IEnumerable<UserResponse>> GetUsers()
    {
        var url = API.User.GetUsers(_remoteServiceBaseUrl);
        var response = await _httpClient.GetRequestAsync<ApiResponse<IEnumerable<UserResponse>>, IEnumerable<UserResponse>>(url);

        return response;
    }
}