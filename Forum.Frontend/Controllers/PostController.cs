using Forum.Domain.Commands.Post.Create;
using Forum.Domain.Commands.User.Register;
using Forum.Domain.Queries.DTOs;
using Forum.Domain.Queries.User.VerifyUserLogin;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Forum.Frontend.Controllers
{
    public class PostController : Controller
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserPostDTO model)
        {
            try
            {
                long.TryParse(User.FindFirstValue("Id"), out long userId);

                var command = new CreateNewPostCommand(model.Title, model.Content, userId);
                var result = await _mediator.Send(command);

                if (result.IsSuccess)
                {
                    return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
                }

                foreach (var error in result.Errors)
                {
                    var key = string.IsNullOrWhiteSpace(error.PropertyName) ? "Global" : error.PropertyName;
                    ModelState.AddModelError(error.PropertyName, error.Message);
                }

                var allErrors = ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(
                    x => x.Key,
                    x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());

                return Json(new { success = false, errors = allErrors });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    errors = new Dictionary<string, string[]>
                    {
                        { "", new[] { "Błąd serwera: " + ex.Message } }
                    }
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAnswer()
        {
			try
			{
				long.TryParse(User.FindFirstValue("Id"), out long userId);

				var command = new CreateNewPostCommand(model.Title, model.Content, userId);
				var result = await _mediator.Send(command);

				if (result.IsSuccess)
				{
					return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
				}

				foreach (var error in result.Errors)
				{
					var key = string.IsNullOrWhiteSpace(error.PropertyName) ? "Global" : error.PropertyName;
					ModelState.AddModelError(error.PropertyName, error.Message);
				}

				var allErrors = ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(
					x => x.Key,
					x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());

				return Json(new { success = false, errors = allErrors });
			}
			catch (Exception ex)
			{
				return Json(new
				{
					success = false,
					errors = new Dictionary<string, string[]>
					{
						{ "", new[] { "Błąd serwera: " + ex.Message } }
					}
				});
			}
		}
    }
}
