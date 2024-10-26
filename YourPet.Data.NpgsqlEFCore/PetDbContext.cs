﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using YourPet.Domain.Entities;

namespace YourPet.Data.NPgsqlEfCore
{
	public class PetDbContext(DbContextOptions<PetDbContext> options) : DbContext(options)
	{
		public DbSet<Pet> Pets { get; set; }
		public DbSet<AppUser> AppUsers { get; set; }
		public DbSet<Event> Events { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetDbContext).Assembly);
		}
	}

	public class PetDbContextDesignFactory : IDesignTimeDbContextFactory<PetDbContext>
	{
		public PetDbContext CreateDbContext(string[] args)
		{
			var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false)
				.AddJsonFile($"appsettings.{env}.json", optional: true)
				.Build();

			var connectionString = configuration.GetConnectionString("DefaultConnection");

			var optionsBuilder = new DbContextOptionsBuilder<PetDbContext>()
				.UseNpgsql(connectionString, options =>
				{
					options.MigrationsAssembly(typeof(PetDbContext).Assembly.GetName().Name);
					// Additional Npgsql configuration options can go here
				});

			return new PetDbContext(optionsBuilder.Options);
		}
	}
}
