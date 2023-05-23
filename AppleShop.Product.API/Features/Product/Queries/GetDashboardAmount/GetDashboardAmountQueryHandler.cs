using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.Infrastructure;
using AppleShop.Product.API.Response;
using Microsoft.EntityFrameworkCore;

namespace AppleShop.Product.API.Features.Product.Queries.GetDashboardAmount;

public class GetDashboardAmountQueryHandler : IQueryHandler<GetDashboardAmountQuery, Dictionary<string, int>>
{
    private readonly ProductDbContext _dbContext;

    public GetDashboardAmountQueryHandler(ProductDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<ApiResponse<Dictionary<string, int>>> Handle(GetDashboardAmountQuery request, CancellationToken cancellationToken)
        => ApiResponse<Dictionary<string, int>>.Success(await _dbContext.Products
            .Include(c => c.Category)
            .GroupBy(c => c.Category.Name, (name, product) => new
            {
                Name = name,
                Amount = product.Count()
            })
            .AsNoTracking()
            .ToDictionaryAsync(x => x.Name, y => y.Amount));
}