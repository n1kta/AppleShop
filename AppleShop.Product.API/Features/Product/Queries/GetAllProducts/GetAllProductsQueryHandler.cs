using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.Infrastructure;
using AppleShop.Product.API.Response;
using AppleShop.Product.API.Wrappers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AppleShop.Product.API.Features.Product.Queries.GetAllProducts;

public sealed class GetAllProductsQueryHandler : IPagedQueryHandler<GetAllProductsQuery, IReadOnlyCollection<ProductDetailResponse>>
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

    public async Task<PagedResponse<IReadOnlyCollection<ProductDetailResponse>>> Handle(
        GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _dbContext.Products
            .Include(product => product.Category)
            .Where(product => product.AvailableStock > 0)
            .Where(product => request.CategoryId == Guid.Empty || product.CategoryId == request.CategoryId)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .AsNoTracking()
            .ToListAsync();

        var prdouctsAmount = await _dbContext.Products.Where(product => product.AvailableStock > 0).CountAsync();

        var result = _mapper.Map<List<ProductDetailResponse>>(products);
        var pagedResult = new PagedResponse<IReadOnlyCollection<ProductDetailResponse>>(request.CategoryId,
            result,
            request.PageNumber,
            request.PageSize,
            prdouctsAmount);

        return pagedResult;
    }
}