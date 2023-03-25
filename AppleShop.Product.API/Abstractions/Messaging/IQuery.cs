using MediatR;

namespace AppleShop.Product.API.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<TResponse>
{

}