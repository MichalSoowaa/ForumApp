using Forum.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Forum.Frontend.Extensions
{
	public static class ForumDependencyInjection
	{
		public static IServiceCollection ForumAddApplication(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ForumTicketDbContext>(options =>
				options.UseSqlServer(
					configuration.GetConnectionString("DefaultConnectionString"),
					x => x.MigrationsHistoryTable("__EFMigrationHistory", "Forum")));

			return services;
		}
	}
}
