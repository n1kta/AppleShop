using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.Enums;
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
        var productsQuery = ProductQuery(request);

        var products = await productsQuery
            .AsNoTracking()
            .ToListAsync();

        var prdouctsAmountQuery = ProductAmountQuery(request);

        var prdouctsAmount = await prdouctsAmountQuery.CountAsync();

        var result = _mapper.Map<List<ProductDetailResponse>>(products);
        var pagedResult = new PagedResponse<IReadOnlyCollection<ProductDetailResponse>>(request.CategoryId,
            result,
            request.PageNumber,
            request.PageSize,
            prdouctsAmount)
        {
            Color = request.Color,
            MinPrice = request.MinPrice,
            MaxPrice = request.MaxPrice,
            Memory = request.Memory
        };

        return pagedResult;
    }

    private IQueryable<Models.Product> ProductAmountQuery(GetAllProductsQuery request)
    {
        var prdouctsAmountQuery = _dbContext.Products.Where(product => product.AvailableStock > 0);

        if (request.CategoryId != Guid.Empty)
            prdouctsAmountQuery = prdouctsAmountQuery.Where(product => product.CategoryId == request.CategoryId);

        if (request.Color != null)
        {
            var color = ((ColorType)request.Color);
            prdouctsAmountQuery = prdouctsAmountQuery.Where(product => product.Color == color);
        }

        if (request.MinPrice != null)
            prdouctsAmountQuery = prdouctsAmountQuery.Where(product => product.Price >= request.MinPrice);

        if (request.MaxPrice != null)
            prdouctsAmountQuery = prdouctsAmountQuery.Where(product => product.Price <= request.MaxPrice);

        if (request.Memory != null)
            prdouctsAmountQuery = prdouctsAmountQuery.Where(product => product.Memory == request.Memory);
        return prdouctsAmountQuery;
    }

    private IQueryable<Models.Product> ProductQuery(GetAllProductsQuery request)
    {
        var productsQuery = _dbContext.Products
                    .Include(product => product.Category)
                    .Where(product => product.AvailableStock > 0);

        if (request.CategoryId != Guid.Empty)
            productsQuery = productsQuery.Where(product => product.CategoryId == request.CategoryId);

        if (request.Color != null)
        {
            var color = ((ColorType)request.Color);
            productsQuery = productsQuery.Where(product => product.Color == color);
        }

        if (request.MinPrice != null)
            productsQuery = productsQuery.Where(product => product.Price >= request.MinPrice);

        if (request.MaxPrice != null)
            productsQuery = productsQuery.Where(product => product.Price <= request.MaxPrice);

        if (request.Memory != null)
            productsQuery = productsQuery.Where(product => product.Memory == request.Memory);

        productsQuery = productsQuery
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize);
        return productsQuery;
    }
}