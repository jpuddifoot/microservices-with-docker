using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PlatformService.Data
{

	public static class PrepDb
	{
		public static void PrepPopulation(this IApplicationBuilder app)
		{
			using(var serviceScope = app.ApplicationServices.CreateScope()){
				SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
			}
		}


		private static void SeedData(AppDbContext context)
		{
			if(!context.Platforms.Any()){
				Console.WriteLine("Seeding data");
				context.Platforms.AddRange(
					new Models.PlatformModel { Name = "DotNet", Publisher = "Microsoft", Cost = "7" },
					new Models.PlatformModel { Name = "Github", Publisher = "Microsoft", Cost = "0" },
					new Models.PlatformModel { Name = "SQL", Publisher = "Microsoft", Cost = "70" }

				);
				context.SaveChanges();
			}
			else{
				Console.WriteLine("Data already seeded");
			}
		}
	}
}