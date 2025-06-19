using FluentValidation.Results;

namespace Forum.Domain.Commands
{
	public class Result
	{
		public string Message { get; }
		public bool IsFailure { get; }
		public bool IsSuccess { get; }
		public IEnumerable<Error> Errors { get; }

		private Result(bool isSuccess, string message, IEnumerable<Error> errors)
		{
			IsSuccess = isSuccess;
			IsFailure = !isSuccess;
			Message = message;
			Errors = errors;
		}

		public static Result Fail(string message) => new Result(false, message, Enumerable.Empty<Error>());

		public static Result Fail(ValidationResult validationResult)
			=> new Result(
				false,
				string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)),
				validationResult.Errors.Select(x => new Error(x.PropertyName, x.ErrorMessage)));

		public static Result Ok() => new Result(true, "", Enumerable.Empty<Error>());

		public class Error
		{
			public string PropertyName { get; set; }
			public string Message { get; set; }

			public Error(string propertyName, string message)
			{
				PropertyName = propertyName;
				Message = message;
			}
		}
	}
}
