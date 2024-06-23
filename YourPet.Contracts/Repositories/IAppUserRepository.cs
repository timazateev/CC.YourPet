namespace YourPet.Contracts;

public interface IAppUserRepository : IEntityRepository
{
    Task<IEnumerable<AppUserDto>> GetAllAppUsersAsync();
    Task<AppUserDto> AddAppUserAsync(AppUserDto account);
    Task<AppUserDto> UpdateAppUserAsync(AppUserDto account);
    Task<bool> AnyAppUserAsync(AppUserDto account);
}