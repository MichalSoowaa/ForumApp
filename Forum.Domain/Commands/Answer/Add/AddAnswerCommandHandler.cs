using Forum.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.Commands.Answer.Add
{
	public class AddAnswerCommandHandler : IRequestHandler<AddAnswerCommand, Result>
	{
		private readonly IAnswersRepository _answersRepository;
		private readonly IUsersRepository _usersRepository;
		private readonly IPostsRepository _postsRepository;

		public AddAnswerCommandHandler(IAnswersRepository answersRepository, IUsersRepository usersRepository, IPostsRepository postsRepository)
		{
			_answersRepository = answersRepository;
			_usersRepository = usersRepository;
			_postsRepository = postsRepository;
		}

		public async Task<Result> Handle(AddAnswerCommand command, CancellationToken cancellationToken)
		{
			var validator = new AddAnswerCommandValidator();
			var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                return Result.Fail(validationResult);

   //         var user = await _usersRepository.GetUserByIdAsync(command.UserId);

   //         if (user == null)
   //             return Result.Fail("Nie ma takiego użytkownika???");

			//var post = await 

   //         var post = new Forum.Domain.Entities.Post(command.Title, command.Content, user);

			var answer = new Forum.Domain.Entities.Answer(command.Content, command.PostId, command.UserId);

            await _answersRepository.AddAnswerAsync(answer);

            return Result.Ok();
        }
	}
}
