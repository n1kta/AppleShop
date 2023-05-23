using AppleShop.Product.API.Wrappers;
using MediatR;

namespace AppleShop.Product.API.Abstractions.Messaging;

public interface IPagedQuery<TResponse> : IRequest<PagedResponse<TResponse>>
{

}