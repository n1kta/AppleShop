using AppleShop.Web.Models;
using AppleShop.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppleShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
            => _productService = productService;

        public async Task<IActionResult> Index(Guid? id, int pageNumber = 1, int pageSize = 10)
        {
            var products = await _productService.GetAll(id, pageNumber, pageSize);

            var result = new ProductListViewModel { Products = products };

            return View(result);
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            var product = await _productService.GetById(id);

            var result = new ProductDetailViewModel { Product = product };

            return View(result);
        }
    }
}
