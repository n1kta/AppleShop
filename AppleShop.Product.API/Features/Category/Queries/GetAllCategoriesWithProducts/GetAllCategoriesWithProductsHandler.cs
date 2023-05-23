using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.Infrastructure;
using AppleShop.Product.API.Response;
using Microsoft.EntityFrameworkCore;

namespace AppleShop.Product.API.Features.Category.Queries.GetAllCategoriesWithProducts;

public class GetAllCategoriesWithProductsHandler : IQueryHandler<GetAllCategoriesWithProductsQuery, IReadOnlyCollection<CategoryWithProductsResponse>>
{
    private readonly ProductDbContext _dbContext;

    public GetAllCategoriesWithProductsHandler(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ApiResponse<IReadOnlyCollection<CategoryWithProductsResponse>>> Handle(GetAllCategoriesWithProductsQuery request, CancellationToken cancellationToken)
        => ApiResponse<IReadOnlyCollection<CategoryWithProductsResponse>>.Success(
            await _dbContext.Categories
                .Include(c => c.Products)
                .Select(c => new CategoryWithProductsResponse(c.Id, c.Name, c.Products.Select(p => new ProductResponse(p.Id, p.Name)).ToList()))
                .AsNoTracking()
                .ToListAsync()
            );
}