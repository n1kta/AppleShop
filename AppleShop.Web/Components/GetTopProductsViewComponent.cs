using AppleShop.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppleShop.Web.Components;

public class GetTopProductsViewComponent : ViewComponent
{
    private readonly IProductService _productService;

    public GetTopProductsViewComponent(IProductService productService)
        => _productService = productService;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View(await _productService.GetTopProducts());
    }
}