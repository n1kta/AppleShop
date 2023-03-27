using AppleShop.Product.API.Features.CatalogFeatures.Commands.CreateProduct;
using AppleShop.Product.API.Features.CatalogFeatures.Queries.GetAllProducts;
using AppleShop.Product.API.Features.CatalogFeatures.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AppleShop.Product.API.Features.CatalogFeatures.Commands.DeleteProductById;
using AppleShop.Product.API.Features.CatalogFeatures.Commands.UpdateProduct;
using AppleShop.Product.API.Response;
using System.Net;

namespace AppleShop.Product.API.Controllers.V1;

[Route("api/v1/[controller]")]
public class ProductController : ApiController
{
    public ProductController(ISender sender)
        : base(sender)
    {
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<List<ProductResponse>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllProductsQuery();

        var response = await Sender.Send(query, cancellationToken);

        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponse<ProductResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetProductByIdQuery(id);

        var response = await Sender.Send(query, cancellationToken);

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<Guid>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Create(
        [FromBody] CreateProductCommand product,
        CancellationToken cancellationToken)
    {
        var response = await Sender.Send(product, cancellationToken);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse<Guid>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteProductByIdCommand(id);
        var response = await Sender.Send(command, cancellationToken);

        return Ok(response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponse<Guid>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(Guid id, UpdateProductCommand command, CancellationToken cancellationToken)
    {
        if (id != command.Id)
            return BadRequest();

        var response = await Sender.Send(command, cancellationToken);

        return Ok(response);
    }
}