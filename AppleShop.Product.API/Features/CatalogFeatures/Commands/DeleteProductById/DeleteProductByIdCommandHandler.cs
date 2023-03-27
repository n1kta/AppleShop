using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.ErrorMessages;
using AppleShop.Product.API.Exceptions;
using AppleShop.Product.API.Infrastructure;
using AppleShop.Product.API.Response;

namespace AppleShop.Product.API.Features.CatalogFeatures.Commands.DeleteProductById;

public sealed class DeleteProductByIdCommandHandler : ICommandHandler<DeleteProductByIdCommand, Guid>
{
    private readonly ProductDbContext _dbContext;

    public DeleteProductByIdCommandHandler(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ApiResponse<Guid>> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products.FindAsync(request.Id);

        if (product is null)
            throw new ApiException(ProductErrorMessage.ProductDoesNotExist);

        product.IsDeleted = true;

        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();

        return ApiResponse<Guid>.Success(product.Id);
    }
}