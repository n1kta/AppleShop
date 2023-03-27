using AppleShop.Product.API.Response;
using MediatR;

namespace AppleShop.Product.API.Abstractions.Messaging;

public interface ICommand : IRequest
{

}

public interface ICommand<TResponse> : IRequest<ApiResponse<TResponse>>
{

}