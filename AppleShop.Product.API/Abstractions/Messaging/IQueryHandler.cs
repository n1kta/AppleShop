using AppleShop.Product.API.Response;
using MediatR;

namespace AppleShop.Product.API.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, ApiResponse<TResponse>>
    where TQuery : IQuery<TResponse>
{

}