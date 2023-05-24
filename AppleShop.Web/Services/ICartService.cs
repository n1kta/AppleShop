using AppleShop.Web.Services.ModelRequests.Cart;

namespace AppleShop.Web.Services;

public interface ICartService
{
    Task<CartDto?> GetCartByUserIdAsync(string userId, string token);

    Task<CartDto?> AddCartAsync(CartDto cartDto, string token);

    Task<CartDto?> UpdateCartAsync(CartDto cartDto, string token);

    Task<bool> RemoveFromCartAsync(int cartId, string token);

    Task<T> Checkout<T>(CartHeaderDto dto, string token);
}