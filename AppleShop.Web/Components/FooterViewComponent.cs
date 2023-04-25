using Microsoft.AspNetCore.Mvc;

namespace AppleShop.Web.Components;

public class FooterViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}