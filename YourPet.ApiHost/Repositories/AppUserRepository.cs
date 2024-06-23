using YourPet.ApiHost.Extensions;
using YourPet.Contracts;
using YourPet.Data.Contracts;

namespace YourAppUser.ApiHost.Repositories
{
    public class AppUserRepository(ILogger<AppUserRepository> logger, IAppUserDa appUserDa) : IAppUserRepository
    {
        private readonly ILogger<AppUserRepository> _logger = logger;

        public async Task<AppUserDto> AddAppUserAsync(AppUserDto appUserDto)
        {
            YourPet.Domain.Entities.AppUser appUser = appUserDto.FromDto();
            return (await appUserDa.AddAppUserAsync(appUser)).ToDto();
        }

        public async Task<IEnumerable<AppUserDto>> GetAllAppUsersAsync()
        {
            return (await appUserDa.GetAllAppUsersAsync()).Map();
        }

        public async Task<AppUserDto> UpdateAppUserAsync(AppUserDto AppUser)
        {
            return (await appUserDa.UpdateAppUserAsync(AppUser.FromDto())).ToDto();
        }

        public async Task DeleteAsync(int id)
        {
            await appUserDa.DeleteAsync(id);
        }

		public async Task<bool> AnyAppUserAsync(AppUserDto account)
		{
            return await appUserDa.AnyAppUserAsync(account.FromDto());
		}
	}
}
