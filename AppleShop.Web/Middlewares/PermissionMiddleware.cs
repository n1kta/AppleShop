namespace AppleShop.Web.Middlewares;

public class PermissionMiddleware
{
    private readonly RequestDelegate _next;

    public PermissionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        var isAdmin = httpContext!.User.Identity != null
            && httpContext!.User.Identity.IsAuthenticated
            && httpContext!.User.Claims.Any(claim => claim.Value.ToLower().Contains("admin"));

        if (isAdmin && !httpContext.Request.Path.Value.ToLower().Contains("/admin"))
        {
            httpContext.Response.Redirect("/Admin");
        }
        else if (!isAdmin && httpContext.Request.Path.Value.ToLower().Contains("/admin"))
        {
            httpContext.Response.Redirect("/");
        }

        await _next(httpContext);
    }
}