using Forum.Domain.Commands.User.Register;
using Forum.Domain.Queries.DTOs;
using Forum.Domain.Queries.User.VerifyUserLogin;
using Forum.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Forum.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
				var errors = ModelState
		            .Where(x => x.Value.Errors.Count > 0)
		            .ToDictionary(
			            kvp => kvp.Key,
			            kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
		            );

				return Json(new { success = false, errors });
			}
                
            var user = await _mediator.Send(new VerifyUserLoginQuery(model.Email, model.Password));

            if(user == null)
            {
                return Json(new { success = false });
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("Id", user.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity)
                );

            return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDTO model)
        {
            try
            {
                var command = new RegisterUserCommand(model.Username, model.Email, model.Password, model.ConfirmedPassword);

				var result = await _mediator.Send(command);

                if (result.IsSuccess)
                {
                    //TempData["SuccessMessage"] = "Rejestracja przebiegła pomyślnie";
                    var user = await _mediator.Send(new VerifyUserLoginQuery(model.Email, model.Password));

                    if (user == null)
                        return Json(new { success = false, redirectUrl = Url.Action("Index", "Home") });

					var claims = new List<Claim>
			        {
				        new Claim(ClaimTypes.Name, user.Username),
				        new Claim("Id", user.Id.ToString())
			        };

					var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

					await HttpContext.SignInAsync(
						CookieAuthenticationDefaults.AuthenticationScheme,
						new ClaimsPrincipal(claimsIdentity));

					return Json(new { success = true, redirectUrl = Url.Action("Index", "Home")});
                }

				ModelState.Clear();

				foreach (var error in result.Errors)
                {           
                    ModelState.AddModelError(error.PropertyName, error.Message);
                }

                var allErrors = ModelState.ToDictionary(
                    x => x.Key,
                    x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());

                return Json(new { success = false, errors = allErrors });
            }
            catch (Exception ex)
            {
                //throw new Exception();

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
