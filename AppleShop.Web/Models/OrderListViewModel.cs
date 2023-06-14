using AppleShop.Web.Services.ModelResponse;

namespace AppleShop.Web.Models;

public class OrderListViewModel
{
    public IEnumerable<OrderResponse> Orders { get; set; }
}