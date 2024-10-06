namespace YourPet.Contracts.Repositories;

public interface IAppUserRepository : IEntityRepository
{
	Task<IEnumerable<AppUserDto>> GetAllAppUsersAsync();
	Task<AppUserDto> AddAppUserAsync(AppUserDto account);
	Task<AppUserDto> UpdateAppUserAsync(AppUserDto account);
	Task<bool> AnyAppUserAsync(AppUserDto account);
	Task<AppUserDto?> GetAppUserByAuth0IdOrDefaultAsync(string auth0Id);
}