using Forum.Domain.Queries.Post.GetAllPosts;
using Forum.Frontend.Models;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Forum.Frontend.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private readonly IMediator _mediator;

		public HomeController(ILogger<HomeController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		public async Task<IActionResult> Index()
		{
			var posts = await _mediator.Send(new GetAllPostsQuery());

			return View(posts);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
