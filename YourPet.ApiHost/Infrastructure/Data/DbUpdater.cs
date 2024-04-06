using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Diagnostics;

namespace YourPet.ApiHost.Infrastructure
{
	public static class DbUpdater
    {
        public static void MigrateDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<Data.NPgsqlEfCore.PetDbContext>();
            Log.Information("Migrate database...");
            var sw = Stopwatch.StartNew();
            context.Database.Migrate();
            sw.Stop();
            Log.Information("Database migrated in {Elapsed} ms", sw.ElapsedMilliseconds);
        }
    }
}
