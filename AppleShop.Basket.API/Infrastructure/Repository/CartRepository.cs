using AppleShop.Basket.API.Infrastructure;
using AppleShop.Basket.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AppleShop.Basket.API.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ShoppingCartDbContext _context;

        public CartRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ClearCart(string userId)
        {
            var cartHeader = await _context.CartHeaders.FirstOrDefaultAsync(u => u.UserId == userId);

            if (cartHeader == null)
                return false;

            _context.CartDetails
                    .RemoveRange(_context.CartDetails.Where(u => u.CartHeaderId == cartHeader.CartHeaderId));
            _context.CartHeaders.Remove(cartHeader);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Cart> CreateUpdateCart(Cart cart)
        {
            var cartHeader = await _context.CartHeaders
                .FirstOrDefaultAsync(ch => ch.UserId == cart.CartHeader.UserId);

            if (cartHeader == null)
            {
                _context.CartHeaders.Add(cart.CartHeader);
                await _context.SaveChangesAsync();

                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.CartHeaderId;
                cart.CartDetails.FirstOrDefault().Product = null;
                _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                await _context.SaveChangesAsync();
            }
            else
            {
                var cartDetail = await _context.CartDetails.FirstOrDefaultAsync(
                    cd => cd.ProductId == cart.CartDetails.FirstOrDefault().ProductId &&
                    cd.CartHeaderId == cartHeader.CartHeaderId);

                if (cartDetail == null)
                {
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartHeader.CartHeaderId;
                    cart.CartDetails.FirstOrDefault().Product = null;
                    _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
                else
                {
                    cart.CartDetails.FirstOrDefault().Product = null;
                    cart.CartDetails.FirstOrDefault().Count += cartDetail.Count;
                    cart.CartDetails.FirstOrDefault().CartDetailId = cartDetail.CartDetailId;
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartDetail.CartHeaderId;
                    _context.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
            }

            return cart;
        }

        public async Task<Cart> GetCartByUserId(string userId)
        {
            Cart cart = new()
            {
                CartHeader = await _context.CartHeaders.FirstOrDefaultAsync(u => u.UserId == userId)
            };

            cart.CartDetails = _context.CartDetails
                .Where(u => u.CartHeaderId == cart.CartHeader.CartHeaderId).Include(u => u.Product);

            return cart;
        }

        public async Task<bool> RemoveFromCart(int cartDetailId)
        {
            try
            {
                var cartDetails = await _context.CartDetails
                    .FirstOrDefaultAsync(u => u.CartDetailId == cartDetailId);

                int totalCountOfCartItems = _context.CartDetails
                    .Where(u => u.CartHeaderId == cartDetails.CartHeaderId).Count();

                _context.CartDetails.Remove(cartDetails);
                if (totalCountOfCartItems == 1)
                {
                    var cartHeaderToRemove = await _context.CartHeaders
                        .FirstOrDefaultAsync(u => u.CartHeaderId == cartDetails.CartHeaderId);

                    _context.CartHeaders.Remove(cartHeaderToRemove);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
