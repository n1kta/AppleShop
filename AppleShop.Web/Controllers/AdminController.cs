using AppleShop.Web.Domain.Services;
using AppleShop.Web.Models;
using AppleShop.Web.Services;
using AppleShop.Web.Services.ModelRequests.Product;
using AppleShop.Web.Services.ModelResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Xml.Linq;

namespace AppleShop.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        private readonly IPhotoService _photoService;

        public AdminController(
            IProductService productService,
            ICategoryService categoryService,
            IOrderService orderService,
            IPhotoService photoService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderService = orderService;
            _photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        #region Product Actions

        public async Task<IActionResult> ProductList()
        {
            var products = await _productService.GetAll(Guid.Empty, pageSize: 1000);

            var result = new ProductListViewModel { Products = products };

            return View(result);
        }

        public async Task<IActionResult> CreateProduct()
        {
            return View();
        }

        [HttpPost]
        [ActionName("CreateProduct")]
        public async Task<IActionResult> CreateProductPost(CreateProductModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var pictureUri = (await _photoService.AddPhotoAsync(model.Picture))?
                .SecureUri?
                .AbsoluteUri ?? string.Empty;

            var request = new CreateProductRequest(
                model.Name,
                model.Description,
                (ColorTypeResponse) model.Color,
                model.Memory,
                model.AvailableStock,
                pictureUri,
                model.Price,
                model.CategoryId);

            var response = await _productService.Create(request);

            return Redirect(nameof(ProductList));
        }

        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
                return Redirect("/Admin/ProductList");

            var categories = await _categoryService.GetAll();

            var model = new UpdateProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Color = (int)product.Color,
                Memory = product.Memory,
                AvailableStock = product.AvailableStock,
                Price = product.Price,
                Picture = null,
                CategoryId = categories.First(c => c.Name == product.CategoryName).Id,
                Series = product.Series
            };

            return View(model);
        }

        [HttpPost]
        [ActionName("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductModel model)
        {
            if (!ModelState.IsValid)
                return View(model.Id);

            if (model == null)
                return Redirect("/Admin/ProductList");

            var pictureUri = string.Empty;

            if (model.Picture != null)
                pictureUri = (await _photoService.AddPhotoAsync(model.Picture))?
                .SecureUri?
                .AbsoluteUri ?? string.Empty;

            var request = new UpdateProductRequest(model.Id,
                model.Name,
                model.Description,
                (ColorTypeResponse)model.Color,
                model.Memory,
                model.AvailableStock,
                pictureUri,
                model.Price,
                model.CategoryId,
                model.Series);

            var product = await _productService.Update(model.Id, request);

            return Redirect("/Admin/ProductList");
        }

        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            if (id == Guid.Empty)
                return Redirect(nameof(ProductList));

            var response = await _productService.Delete(id);

            return Redirect("/Admin/ProductList");
        }

        #endregion

        #region Order Actions

        public async Task<IActionResult> OrderList()
        {
            var orders = await _orderService.GetAll();

            var result = new OrderListViewModel { Orders = orders };

            return View(result);
        }

        #endregion
    }
}
