using AppleShop.Web.Services;
using AppleShop.Web.Services.ModelRequests.Cart;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AppleShop.Web.Controllers;

public class CartController : Controller
{
    private readonly IProductService _productService;
    private readonly ICartService _cartService;

    public CartController(
            IProductService productService,
            ICartService cartService
            )
    {
        _productService = productService;
        _cartService = cartService;
    }

    public async Task<IActionResult> CartIndex()
    {
        return View(await LoadCartDtoBasedOnLoggedInUser());
    }

    public async Task<IActionResult> Checkout()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Checkout(CartDto dto)
    {
        return Ok();
        //try
        //{
        //    var accessToken = await HttpContext.GetTokenAsync("access_token");
        //    var response = await _cartService.Checkout<>(dto.CartHeader, accessToken);

        //    if (!response.IsSuccess)
        //    {
        //        ViewBag.Error = string.Join(", ", response.ErrorMessages);
        //        return RedirectToAction(nameof(Checkout));
        //    }

        //    return RedirectToAction(nameof(Confirmation));
        //}
        //catch (Exception)
        //{
        //    return View(dto);
        //}
    }

    [HttpGet]
    public async Task<IActionResult> Confirmation()
    {
        return View();
    }

    private async Task<CartDto?> LoadCartDtoBasedOnLoggedInUser()
    {
        var userId = User.Claims.FirstOrDefault(u => u.Type == "sub")?.Value;
        var accessToken = await HttpContext.GetTokenAsync("access_token");

        var cartDto = await _cartService.GetCartByUserIdAsync(userId, accessToken);

        if (cartDto is null)
            return null;

        if (cartDto.CartHeader != null)
        {
            cartDto.CartHeader.OrderTotal =
                cartDto.CartDetails.Sum(cd => cd.Product.Price * cd.Count) - cartDto.CartHeader.DiscountTotal;
        }

        return cartDto;
    }
}