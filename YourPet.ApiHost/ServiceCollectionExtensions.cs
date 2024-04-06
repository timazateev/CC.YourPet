using YourPet.ApiHost.Repositories;
using YourPet.Contracts;

namespace YourPet.ApiHost
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessService<IService, TService>(this IServiceCollection services)
            where TService : class, IService
            where IService : class
        {

            services.AddScoped<IService>(serviceProvider =>
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                if (!string.IsNullOrEmpty(connectionString))
                {
                    return (IService)ActivatorUtilities.CreateInstance(serviceProvider, typeof(TService),
                        connectionString);
                }
                else
                {
                    throw new InvalidOperationException("Database credentials not provided");
                }
            });
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IPetRepository, PetRepository>();
        }
    }
}
