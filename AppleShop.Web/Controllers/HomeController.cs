using AppleShop.Web.Models;
using AppleShop.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AppleShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOptions<AppSettings> _settings;

        public HomeController(IProductService productService, IOptions<AppSettings> settings)
        {
            _productService = productService;
            _settings = settings;
        }

        public async Task<IActionResult> Index()
        {
            var dashboardAmount = await _productService.GetDashboardAmount();

            var result = new HomeViewModel(dashboardAmount);

            return View(result);
        }

        public async Task<IActionResult> Register()
        {
            return Redirect($"{_settings.Value.IdentityUrl}/Account/Register?returnUrl={_settings.Value.WebUrl}");
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