using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using YourPet.Data.Contracts;
using YourPet.Domain.Entities;
using YourPet.NPgsqlEfCore;

namespace YourPet.Data.Postgres.DataAdapters
{
    public class AppUserDa(PetDbContext context, ILogger<AppUserDa> logger) : IAppUserDa
    {
        private readonly PetDbContext _context = context;
        private readonly ILogger<AppUserDa> _logger = logger;

		public async Task<AppUser> AddAppUserAsync(AppUser appUser)
        {
            _context.AppUsers.Add(appUser);
            await _context.SaveChangesAsync();
            return appUser;
        }

		public Task<bool> AnyAppUserAsync(AppUser appUser)
		{
            return _context.AppUsers.AnyAsync(u => u.Auth0Id == appUser.Auth0Id || u.Email == appUser.Email);
		}

		public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppUser>> GetAllAppUsersAsync()
        {
            return await _context.AppUsers.ToListAsync();
        }

		public async Task<AppUser?> GetAppUserByAuth0IdOrDefaultAsync(string auth0Id)
		{
            return await _context.AppUsers.FirstOrDefaultAsync(u => u.Auth0Id == auth0Id);
		}

		public async Task<AppUser> UpdateAppUserAsync(AppUser appUser)
		{
			var user = await _context.AppUsers.FirstOrDefaultAsync(u => u.Id == appUser.Id) 
                ?? throw new Exception($"User with ID {appUser.Id} not found.");
			_context.Entry(user).CurrentValues.SetValues(appUser);
			await _context.SaveChangesAsync();

			return user;
		}

	}
}
