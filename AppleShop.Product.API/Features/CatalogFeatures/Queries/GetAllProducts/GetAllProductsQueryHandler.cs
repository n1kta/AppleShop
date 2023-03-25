using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.Infrastructure;
using AppleShop.Product.API.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AppleShop.Product.API.Features.CatalogFeatures.Queries.GetAllProducts;

public sealed class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, List<ProductResponse>>
{
    private readonly ProductDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(
        ProductDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<ProductResponse>> Handle(
        GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _dbContext.Products
            .Include(product => product.Category)
            .Where(product => product.IsAvailable)
            .AsNoTracking()
            .ToListAsync();

        var response = _mapper.Map<List<ProductResponse>>(products);

        return response;
    }
}