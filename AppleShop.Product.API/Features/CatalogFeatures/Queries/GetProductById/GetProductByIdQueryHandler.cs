using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.Infrastructure;
using AppleShop.Product.API.Response;
using AutoMapper;

namespace AppleShop.Product.API.Features.CatalogFeatures.Queries.GetProductById;

public sealed class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductResponse>
{
    private readonly ProductDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(
        ProductDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ProductResponse> Handle(
        GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products
            .FindAsync(request.Id);

        var response = _mapper.Map<ProductResponse>(product);

        return response;
    }
}