using MediatR;

namespace Orders.Application.Configuration.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{
}