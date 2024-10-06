using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using YourPet.NPgsqlEfCore;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddPetDbContext(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("DefaultConnection");

		services.AddDbContext<PetDbContext>(options =>
			options.UseNpgsql(connectionString)
				   .EnableDetailedErrors()
				   .EnableSensitiveDataLogging()
				   .LogTo(Console.WriteLine, LogLevel.Information));

		return services;
	}
}
