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
            //check if product exists in database, if not create it!
            var prodInDb = await _context.Products
                .FirstOrDefaultAsync(u => u.ProductId == cart.CartDetails.FirstOrDefault()
                .ProductId);
            if (prodInDb == null)
            {
                _context.Products.Add(cart.CartDetails.FirstOrDefault().Product);
                await _context.SaveChangesAsync();
            }


            //check if header is null
            var cartHeaderFromDb = await _context.CartHeaders.AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserId == cart.CartHeader.UserId);

            if (cartHeaderFromDb == null)
            {
                //create header and details
                _context.CartHeaders.Add(cart.CartHeader);
                await _context.SaveChangesAsync();
                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.CartHeaderId;
                cart.CartDetails.FirstOrDefault().Product = null;
                _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                await _context.SaveChangesAsync();
            }
            else
            {
                //if header is not null
                //check if details has same product
                var cartDetailsFromDb = await _context.CartDetails.AsNoTracking().FirstOrDefaultAsync(
                    u => u.ProductId == cart.CartDetails.FirstOrDefault().ProductId &&
                    u.CartHeaderId == cartHeaderFromDb.CartHeaderId);

                if (cartDetailsFromDb == null)
                {
                    //create details
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartHeaderFromDb.CartHeaderId;
                    cart.CartDetails.FirstOrDefault().Product = null;
                    _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
                else
                {
                    //update the count / cart details
                    cart.CartDetails.FirstOrDefault().Product = null;
                    cart.CartDetails.FirstOrDefault().Count += cartDetailsFromDb.Count;
                    cart.CartDetails.FirstOrDefault().CartDetailId = cartDetailsFromDb.CartDetailId;
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartDetailsFromDb.CartHeaderId;
                    _context.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
            }

            return cart;
        }

        public async Task<Cart?> GetCartByUserId(string userId)
        {
            var cartHeader = await _context.CartHeaders.FirstOrDefaultAsync(u => u.UserId == userId);

            if (cartHeader is null)
                return null;

            Cart cart = new()
            {
                CartHeader = cartHeader
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
