using AppleShop.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppleShop.Web.Components;

public class HeaderViewComponent : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public HeaderViewComponent(ICategoryService categoryService)
        => _categoryService = categoryService;

    public async Task<IViewComponentResult> InvokeAsync()
        => View(await _categoryService.GetAll());
}