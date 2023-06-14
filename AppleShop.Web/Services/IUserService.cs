using AppleShop.Web.Services.ModelResponse;

namespace AppleShop.Web.Services;

public interface IUserService
{
    Task<IEnumerable<UserResponse>> GetUsers();
}