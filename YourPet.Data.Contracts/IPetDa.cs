using YourPet.Domain.Entities;

namespace YourPet.Data.Contracts
{
	public interface IPetDa : IEntityDa
	{
		Task<IEnumerable<Pet>> GetAllPetsAsync(bool onlyEnabled);
		Task<IEnumerable<Pet>> GetUserPetsAsync(int userId, bool enabled);
		Task<Pet> AddPetAsync(Pet pet, int userId);
		Task<Pet> UpdatePetAsync(Pet pet);
		Task<bool> AssignPetToUserAsync(int petId, int userId);
	}
}
