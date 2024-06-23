using YourPet.ApiHost.Infrastructure.Logging;
using System.Text.Json.Serialization;
using Serilog;
using YourPet.Data.Postgres;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


namespace YourPet.ApiHost
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddPetDbContext(builder.Configuration);
			builder.Services.AddControllers();

			builder.Host.UseSerilogLogging();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDataAdapters(builder.Configuration);
			builder.Services.AddRepositories();

			builder.Services.AddControllers().AddJsonOptions(x =>
			{
				x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
				x.JsonSerializerOptions.IgnoreNullValues = true;
			});

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowSpecificOrigin",
					builder => builder.WithOrigins("http://localhost:3000")
									  .AllowAnyHeader()
									  .AllowAnyMethod());
			});


			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(options =>
				{
					options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}/";
					options.Audience = builder.Configuration["Auth0:Audience"];
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidIssuer = $"https://{builder.Configuration["Auth0:Domain"]}",
						ValidateAudience = true,
						ValidAudience = builder.Configuration["Auth0:Audience"],
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true
					};
				});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			//if (app.Environment.IsDevelopment())
			//{
			app.UseSwagger();
			app.UseSwaggerUI();
			//}

			// Only manual migration at the moment
			//app.MigrateDatabase();

			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/error");
			}

			app.UseHttpsRedirection();

			// Apply CORS policy here
			app.UseCors("AllowSpecificOrigin");

			app.UseSerilogRequestLogging();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
