﻿using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.Response;

namespace AppleShop.Product.API.Features.Product.Queries.GetProductById;

public sealed record GetProductByIdQuery(Guid Id) : IQuery<ProductDetailResponse>;