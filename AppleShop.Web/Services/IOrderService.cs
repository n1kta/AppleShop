using AppleShop.Web.Services.ModelResponse;

namespace AppleShop.Web.Services;

public interface IOrderService
{
    Task<IEnumerable<OrderResponse>> GetAll();
}