using AppleShop.Product.API.Consts;
using AppleShop.Product.API.Response;
using Newtonsoft.Json;
using System.Net;

namespace AppleShop.Product.API.Middlewares;

public class ErrorHandlerMiddleware : IMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var response = context.Response;
            response.ContentType = ContentTypeConst.ApplicationJson;

            var responseModel = ApiResponse<string>.Fail(ex.Message);

            switch (ex)
            {
                case KeyNotFoundException e:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
            }

            var result = JsonConvert.SerializeObject(responseModel);
            await response.WriteAsync(result);
        }
    }
}