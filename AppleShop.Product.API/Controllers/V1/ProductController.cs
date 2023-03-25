using AppleShop.Product.API.Features.CatalogFeatures.Commands.CreateProduct;
using AppleShop.Product.API.Features.CatalogFeatures.Queries.GetAllProducts;
using AppleShop.Product.API.Features.CatalogFeatures.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppleShop.Product.API.Controllers.V1;

[Route("api/v1/[controller]")]
public class ProductController : ApiController
{
    public ProductController(ISender sender)
        : base(sender)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllProductsQuery();

        var response = await Sender.Send(query, cancellationToken);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetProductByIdQuery(id);

        var response = await Sender.Send(query, cancellationToken);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateProductCommand product,
        CancellationToken cancellationToken)
    {
        var response = await Sender.Send(product, cancellationToken);

        return Ok(response);
    }
}