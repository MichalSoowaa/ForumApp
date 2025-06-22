using Forum.Domain.Queries.DTOs;
using Forum.Domain.Queries.User.VerifyUserLogin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
            bool correct = await _mediator.Send(new VerifyUserLoginQuery(model.Email, model.Password));

            if(!correct)
            {
                //ModelState.AddModelError(string.Empty, "Niepoprawne dane");
                //return PartialView("_LoginPartial", model);

                return Json(new { success = false, message = "Niepoprawne dane" });
            }

            return Json(new { success = true });
            //return PartialView("_LoginPartial");
        }
    }
}
