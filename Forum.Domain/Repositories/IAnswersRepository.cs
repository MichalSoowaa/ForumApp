using Forum.Domain.Entities;

namespace Forum.Domain.Repositories
{
	public interface IAnswersRepository
	{
		Task AddAnswerAsync(Answer answer);
	}
}
