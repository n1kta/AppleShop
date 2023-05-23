using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.Infrastructure;
using AppleShop.Product.API.Response;
using AutoMapper;

namespace AppleShop.Product.API.Features.Product.Commands.CreateProduct;

public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>
{
    private readonly ProductDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(
        ProductDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ApiResponse<Guid>> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Models.Product>(request);

        await _dbContext.AddAsync(model);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return ApiResponse<Guid>.Success(model.Id);
    }
}