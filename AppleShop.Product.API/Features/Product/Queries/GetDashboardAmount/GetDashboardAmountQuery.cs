using AppleShop.Product.API.Abstractions.Messaging;
using AppleShop.Product.API.Response;

namespace AppleShop.Product.API.Features.Product.Queries.GetDashboardAmount;

public sealed record GetDashboardAmountQuery() : IQuery<Dictionary<string, int>>;