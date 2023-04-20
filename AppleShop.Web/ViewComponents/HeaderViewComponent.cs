using Microsoft.AspNetCore.Mvc;

namespace AppleShop.Web.ViewComponents;

public class HeaderViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}