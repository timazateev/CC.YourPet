using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using YourPet.Data.Contracts;
using YourPet.Data.NPgsqlEfCore;
using YourPet.Domain.Entities;

namespace YourPet.Data.Postgres.DataAdapters
{
    public class AppUserDa : IAppUserDa
    {
        private readonly PetDbContext _context;
        private readonly ILogger<AppUserDa> _logger;
        public AppUserDa(PetDbContext context, ILogger<AppUserDa> logger)
        {
            _context = context;
            _logger = logger;
        }
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

        public async Task<IEnumerable<AppUser>> GetAllAppUsersAsync()
        {
            return await _context.AppUsers.ToListAsync();
        }

		public async Task<IEnumerable<AppUser>> GetUsersByIds(IEnumerable<int> userIds)
		{
			return await _context.AppUsers.Where(u => userIds.Contains(u.Id)).ToListAsync();
		}

		public async Task<AppUser> UpdateAppUserAsync(AppUser appUser)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(u => u.Id == appUser.Id);
            if (user != null)
            {
                _context.Entry(user).CurrentValues.SetValues(appUser);
                await _context.SaveChangesAsync();
            }
            return user;
        }
    }
}
