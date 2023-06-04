using AppleShop.Web.Models;
using AppleShop.Web.Services;
using AppleShop.Web.Services.ModelRequests.Cart;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppleShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public ProductController(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index(
            Guid? id,
            int? color = null,
            int? minPrice = null,
            int? maxPrice = null,
            int? memory = null,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var products = await _productService.GetAll(id, color, minPrice, maxPrice, memory, pageNumber, pageSize);

            var result = new ProductListViewModel { Products = products };

            return View(result);
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            var product = await _productService.GetById(id);

            var result = new ProductDetailViewModel { Product = product };

            return View(result);
        }

        [HttpPost]
        [ActionName("Detail")]
        [Authorize]
        public async Task<IActionResult> DetailPost(ProductDetailViewModel productDto)
        {
            CartDto cartDto = new()
            {
                CartHeader = new CartHeaderDto
                {
                    UserId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value
                }
            };

            var cartDetails = new CartDetailDto()
            {
                Count = productDto.Product.Count,
                ProductId = productDto.Product.Id
            };

            var productDetail = await _productService.GetById(productDto.Product.Id);

            if (productDetail != null)
            {
                cartDetails.Product = productDetail;
            }

            List<CartDetailDto> cartDetailsDtos = new();
            cartDetailsDtos.Add(cartDetails);
            cartDto.CartDetails = cartDetailsDtos;

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var addToCartResp = await _cartService.AddCartAsync(cartDto, accessToken);
            if (addToCartResp != null && addToCartResp.CartHeader?.CartHeaderId != null)
            {
                return RedirectToAction(nameof(Index), new { id = Guid.Empty });
            }

            return View(productDto);
        }

        public async Task<IActionResult> Real()
        {
            return View();
        }
    }
}
