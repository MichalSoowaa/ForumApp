using MediatR;


namespace Forum.Domain.Commands.Answer.Add
{
	public sealed record AddAnswerCommand(string Content, long PostId, long UserId) : IRequest<Result>;
}
