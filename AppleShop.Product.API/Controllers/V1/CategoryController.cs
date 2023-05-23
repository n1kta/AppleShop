using AppleShop.Product.API.Features.Category.Queries.GetAllCategoriesWithProducts;
using AppleShop.Product.API.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AppleShop.Product.API.Controllers.V1;

[Route("api/v1/[controller]")]
public class CategoryController : ApiController
{
    public CategoryController(ISender sender) 
        : base(sender)
    {
    }

    [HttpGet("getAllWithProducts")]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyCollection<CategoryWithProductsResponse>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllCategoriesWithProductsQuery();

        var response = await Sender.Send(query, cancellationToken);

        return Ok(response);
    }
}