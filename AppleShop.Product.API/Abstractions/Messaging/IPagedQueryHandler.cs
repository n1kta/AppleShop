using AppleShop.Product.API.Wrappers;
using MediatR;

namespace AppleShop.Product.API.Abstractions.Messaging;

public interface IPagedQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, PagedResponse<TResponse>>
    where TQuery : IPagedQuery<TResponse>
{

}