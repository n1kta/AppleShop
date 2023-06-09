﻿using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.ErrorMessages;
using AppleShop.Product.API.Exceptions;
using AppleShop.Product.API.Infrastructure;
using AppleShop.Product.API.Response;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

namespace AppleShop.Product.API.Features.Product.Commands.UpdateProduct;

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

        var pictureUri = string.IsNullOrEmpty(request.PictureUri) ? product.PictureUri : request.PictureUri;

        _mapper.Map(request, product);

        product.PictureUri = pictureUri;

        await _dbContext.SaveChangesAsync();

        return ApiResponse<Guid>.Success(product.Id);
    }
}