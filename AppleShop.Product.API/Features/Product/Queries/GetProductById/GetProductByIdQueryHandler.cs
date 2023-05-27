using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.Infrastructure;
using AppleShop.Product.API.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AppleShop.Product.API.Features.Product.Queries.GetProductById;

public sealed class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDetailResponse>
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

    public async Task<ApiResponse<ProductDetailResponse>> Handle(
        GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == request.Id);

        var result = _mapper.Map<ProductDetailResponse>(product);

        return ApiResponse<ProductDetailResponse>.Success(result);
    }
}