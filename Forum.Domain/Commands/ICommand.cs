using MediatR;

namespace Forum.Domain.Commands
{
	public interface ICommand<TResult> : IRequest<TResult>
	{
	}
}
