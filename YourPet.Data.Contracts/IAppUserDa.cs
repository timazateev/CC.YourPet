using YourPet.Domain.Entities;

namespace YourPet.Data.Contracts
{
    public interface IAppUserDa : IEntityDa
    {
        Task<IEnumerable<AppUser>> GetAllAppUsersAsync();
        Task<AppUser> AddAppUserAsync(AppUser appUser);
        Task<AppUser> UpdateAppUserAsync(AppUser appUser);
		Task<bool> AnyAppUserAsync(AppUser account);
    }
}