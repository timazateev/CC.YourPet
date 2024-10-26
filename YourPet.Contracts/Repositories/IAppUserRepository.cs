namespace YourPet.Contracts.Repositories;

public interface IAppUserRepository
{
	Task<IEnumerable<AppUserDto>> GetAllAppUsersAsync();
	Task<AppUserDto> AddAppUserAsync(AppUserDto account);
	Task<AppUserDto> UpdateAppUserAsync(AppUserDto account);
	Task<bool> AnyAppUserAsync(AppUserDto account);
}