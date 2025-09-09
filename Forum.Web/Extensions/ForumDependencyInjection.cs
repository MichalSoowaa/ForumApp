using Forum.Domain.Commands.Answer.Add;
using Forum.Domain.Commands.Post.Create;
using Forum.Domain.Commands.User.Register;
using Forum.Domain.Queries.Post.GetAllPosts;
using Forum.Domain.Queries.Post.GetPostDetails;
using Forum.Domain.Queries.User.VerifyUserLogin;
using Forum.Domain.Repositories;
using Forum.Infrastructure;
using Forum.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Forum.Web.Extensions
{
	public static class ForumDependencyInjection
	{
		public static IServiceCollection ForumAddApplication(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IPostsRepository, PostsRepository>();
			services.AddScoped<IUsersRepository, UsersRepository>();
			services.AddScoped<IAnswersRepository, AnswersRepository>();

			services.AddDbContext<ForumTicketDbContext>(options =>
				options.UseSqlServer(
					configuration.GetConnectionString("DefaultConnectionString"),
					x => x.MigrationsHistoryTable("__EFMigrationHistory", "Forum")));

			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.LoginPath = "/Account/Login";
					options.LogoutPath = "/Account/Logout";
				});

			services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssembly(typeof(GetAllPostsQuery).Assembly);
				cfg.RegisterServicesFromAssembly(typeof(VerifyUserLoginQuery).Assembly);
				cfg.RegisterServicesFromAssembly(typeof(GetPostDetailsQuery).Assembly);
				cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommand).Assembly);
				cfg.RegisterServicesFromAssembly(typeof(CreateNewPostCommand).Assembly);
				cfg.RegisterServicesFromAssembly(typeof(AddAnswerCommand).Assembly);
			});

			return services;
		}
	}
}
