using AppleShop.Basket.API.Models;

namespace AppleShop.Basket.API.Repository
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByUserId(string userId);

        Task<Cart> CreateUpdateCart(Cart cart);

        Task<bool> RemoveFromCart(int cartDetailId);

        Task<bool> ClearCart(string userId);
    }
}
