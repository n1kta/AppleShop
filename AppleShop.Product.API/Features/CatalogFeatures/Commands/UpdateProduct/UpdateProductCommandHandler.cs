using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.ErrorMessages;
using AppleShop.Product.API.Exceptions;
using AppleShop.Product.API.Infrastructure;
using AppleShop.Product.API.Response;
using AutoMapper;

namespace AppleShop.Product.API.Features.CatalogFeatures.Commands.UpdateProduct;

public sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Guid>
{
    private readonly ProductDbContext _dbContext;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(
        ProductDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ApiResponse<Guid>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products.FindAsync(request.Id);

        if (product is null)
            throw new ApiException(ProductErrorMessage.ProductDoesNotExist);

        _mapper.Map(request, product);

        await _dbContext.SaveChangesAsync();

        return ApiResponse<Guid>.Success(product.Id);
    }
}