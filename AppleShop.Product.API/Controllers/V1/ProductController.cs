using AppleShop.Product.API.Features.Product.Commands.CreateProduct;
using AppleShop.Product.API.Features.Product.Queries.GetAllProducts;
using AppleShop.Product.API.Features.Product.Queries.GetProductById;
using AppleShop.Product.API.Features.Product.Commands.DeleteProduct;
using AppleShop.Product.API.Features.Product.Commands.UpdateProduct;
using AppleShop.Product.API.Features.Product.Queries.GetDashboardAmount;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AppleShop.Product.API.Response;
using System.Net;
using AppleShop.Product.API.Features.Product.Queries.GetTopProducts;
using Microsoft.AspNetCore.Authorization;

namespace AppleShop.Product.API.Controllers.V1;

[Route("api/v1/[controller]")]
public class ProductController : ApiController
{
    public ProductController(ISender sender)
        : base(sender)
    {
    }

    //[Authorize(Roles = "Customer")]
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<List<ProductDetailResponse>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll(
        Guid id,
        int? color = null,
        int? minPrice = null,
        int? maxPrice = null,
        int? memory = null,
        int pageNumber = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var query = new GetAllProductsQuery(id, color, minPrice, maxPrice, memory, pageNumber, pageSize);

        var response = await Sender.Send(query, cancellationToken);

        return Ok(response);
    }

    //[Authorize(Roles = "Customer")]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponse<ProductDetailResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetProductByIdQuery(id);

        var response = await Sender.Send(query, cancellationToken);

        return Ok(response);
    }

    //[Authorize(Roles = "Admin")]
    [HttpPost("create")]
    [ProducesResponseType(typeof(ApiResponse<Guid>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Create(
        [FromBody] CreateProductCommand product,
        CancellationToken cancellationToken)
    {
        var response = await Sender.Send(product, cancellationToken);

        return Ok(response);
    }

    //[Authorize(Roles = "Admin")]
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(typeof(ApiResponse<Guid>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteProductCommand(id);
        var response = await Sender.Send(command, cancellationToken);

        return Ok(response);
    }

    //[Authorize(Roles = "Admin")]
    [HttpPost("update/{id}")]
    [ProducesResponseType(typeof(ApiResponse<Guid>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(Guid id, UpdateProductCommand command, CancellationToken cancellationToken)
    {
        if (id != command.Id)
            return BadRequest();

        var response = await Sender.Send(command, cancellationToken);

        return Ok(response);
    }

    [HttpGet("getDashboardAmount")]
    public async Task<IActionResult> GetDashboardAmount(CancellationToken cancellationToken)
    {
        var query = new GetDashboardAmountQuery();

        var response = await Sender.Send(query, cancellationToken);

        return Ok(response);
    }

    [HttpGet("getTopProducts")]
    public async Task<IActionResult> GetTopProducts(CancellationToken cancellationToken)
    {
        var query = new GetTopProductsQuery();

        var response = await Sender.Send(query, cancellationToken);

        return Ok(response);
    }
}