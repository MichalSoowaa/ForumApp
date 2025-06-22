using Forum.Domain.Queries.Post.GetAllPosts;
using Forum.Domain.Queries.User.VerifyUserLogin;
using Forum.Domain.Repositories;
using Forum.Infrastructure;
using Forum.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Forum.Frontend.Extensions
{
	public static class ForumDependencyInjection
	{
		public static IServiceCollection ForumAddApplication(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IPostsRepository, PostsRepository>();
			services.AddScoped<IUsersRepository, UsersRepository>();

			services.AddDbContext<ForumTicketDbContext>(options =>
				options.UseSqlServer(
					configuration.GetConnectionString("DefaultConnectionString"),
					x => x.MigrationsHistoryTable("__EFMigrationHistory", "Forum")));

			services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssembly(typeof(GetAllPostsQuery).Assembly);
				cfg.RegisterServicesFromAssembly(typeof(VerifyUserLoginQuery).Assembly);
			});

			return services;
		}
	}
}
