using Forum.Domain.Commands.User.Register;
using Forum.Domain.Queries.DTOs;
using Forum.Domain.Queries.User.VerifyUserLogin;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Forum.Frontend.Controllers
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
        public async Task<IActionResult> Login(UserLoginDTO model)
        {
            var user = await _mediator.Send(new VerifyUserLoginQuery(model.Email, model.Password));

            if(user == null)
            {
                return Json(new { success = false, message = "Niepoprawne dane" });
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("Id", user.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));


            return Json(new { success = true });
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
                var result = await _mediator.Send(
                    new RegisterUserCommand(model.Username, model.Email, model.Password, model.ConfirmedPassword));

                if (result.IsSuccess)
                {
                    TempData["SuccessMessage"] = "Rejestracja przebiegła pomyślnie";
                    await _mediator.Send(new VerifyUserLoginQuery(model.Email, model.Password));

                    return Json(new { success = true, redirectUrl = Url.Action("Index", "Home")});
                }

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
                return Json(new
                {
                    succes = false,
                    errors = new Dictionary<string, string[]>
                    {
                        { "", new[] { "Błąd serwera: " + ex.Message } }
                    }
                });
            }
        }
    }
}
