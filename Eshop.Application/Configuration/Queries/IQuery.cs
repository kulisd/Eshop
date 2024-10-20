using MediatR;

namespace Eshop.Application.Configuration.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{

}