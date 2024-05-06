using YourPet.Data.Contracts;
using YourPet.Data.Postgres.DataAdapters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace YourPet.Data.Postgres
{
	public static class RegistrationEx
	{
		public static IServiceCollection AddDataAdapters(this IServiceCollection services, IConfiguration configuration)
		{
			// Assuming PetDbContext is already configured to use the connection string as shown earlier
			services.AddScoped<IPetDa, PetDa>();
			services.AddScoped<IAppUserDa, AppUserDa>();

			return services;
		}
	}
}