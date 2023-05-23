using AppleShop.Web.Models;
using AppleShop.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppleShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
            => _productService = productService;

        public async Task<IActionResult> Index()
        {
            var dashboardAmount = await _productService.GetDashboardAmount();

            var result = new HomeViewModel(dashboardAmount);

            return View(result);
        }

        [Authorize]
        public async Task<IActionResult> Login()
        {
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}