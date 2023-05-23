using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.Infrastructure;
using AppleShop.Product.API.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AppleShop.Product.API.Features.Product.Queries.GetTopProducts
{
    public class GetTopProductsQueryHandler : IQueryHandler<GetTopProductsQuery, IReadOnlyCollection<ProductDetailResponse>>
    {
        private readonly ProductDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTopProductsQueryHandler(ProductDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IReadOnlyCollection<ProductDetailResponse>>> Handle(
            GetTopProductsQuery request,
            CancellationToken cancellationToken)
        {
            var products = await _dbContext.Products
                .Take(5)
                .AsNoTracking()
                .ToListAsync();

            var result = _mapper.Map<List<ProductDetailResponse>>(products);

            return ApiResponse<IReadOnlyCollection<ProductDetailResponse>>.Success(result);
        }
    }
}
