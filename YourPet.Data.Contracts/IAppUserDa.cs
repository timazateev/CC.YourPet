using YourPet.Domain.Entities;

namespace YourPet.Data.Contracts
{
    public interface IAppUserDa
    {
        Task<IEnumerable<AppUser>> GetAllAppUsersAsync();
        Task<AppUser> AddAppUserAsync(AppUser appUser);
        Task<AppUser> UpdateAppUserAsync(AppUser appUser);
		Task<bool> AnyAppUserAsync(AppUser account);
		Task<IEnumerable<AppUser>> GetUsersByIds(IEnumerable<int> userIds);
	}
}