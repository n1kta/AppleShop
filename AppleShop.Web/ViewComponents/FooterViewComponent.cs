using Microsoft.AspNetCore.Mvc;

namespace AppleShop.Web.ViewComponents;

public class FooterViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}