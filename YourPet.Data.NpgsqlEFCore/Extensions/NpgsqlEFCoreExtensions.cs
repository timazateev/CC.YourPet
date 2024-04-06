using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YourPet.Data.NPgsqlEfCore;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddPetDbContext(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("DefaultConnection");

		services.AddDbContext<PetDbContext>(options =>
			options.UseNpgsql(connectionString)); // UseNpgsql is for PostgreSQL, adjust if using a different database

		return services;
	}
}