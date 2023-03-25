using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.Infrastructure;
using AutoMapper;
using MediatR;

namespace AppleShop.Product.API.Features.CatalogFeatures.Commands.CreateProduct;

public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
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

    public async Task<Unit> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Models.Product>(request);

        await _dbContext.AddAsync(model);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}