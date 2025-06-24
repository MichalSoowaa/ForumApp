using Forum.Domain.Entities;
using Forum.Domain.Repositories;

namespace Forum.Infrastructure.Repositories
{
	public class AnswersRepository : IAnswersRepository
	{
		private readonly ForumTicketDbContext _context;

		public AnswersRepository(ForumTicketDbContext context)
		{
			_context = context;
		}

		public async Task AddAnswerAsync(Answer answer)
		{
			await _context.Answers.AddAsync(answer);
			await _context.SaveChangesAsync();
		}
	}
}
