using FluentValidation;

namespace Forum.Domain.Commands.Post.Create
{
    public class CreateNewPostCommandValidator : AbstractValidator<CreateNewPostCommand>
    {
        public CreateNewPostCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Tytuł nie może być pusta")
                .MaximumLength(256).WithMessage("Maksymalna liczba znaków to 256");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Post nie może być pusty");
        }
    }
}
