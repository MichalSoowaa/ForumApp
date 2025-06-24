using FluentValidation;

namespace Forum.Domain.Commands.Answer.Add
{
	public class AddAnswerCommandValidator : AbstractValidator<AddAnswerCommand>
	{
		public AddAnswerCommandValidator()
		{
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Odpowiedź nie może być pusta");
        }
	}
}
