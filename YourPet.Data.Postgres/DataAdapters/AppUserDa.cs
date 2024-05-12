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

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppUser>> GetAllAppUsersAsync()
        {
            return await _context.AppUsers.ToListAsync();
        }

        public async Task<AppUser> UpdateAppUserAsync(AppUser appUser)
        {
            _context.AppUsers.Add(appUser);
            await _context.SaveChangesAsync();
            return appUser;
        }
    }
}
