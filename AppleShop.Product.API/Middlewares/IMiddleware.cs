namespace AppleShop.Product.API.Middlewares;

public interface IMiddleware
{
    Task Invoke(HttpContext context);
}