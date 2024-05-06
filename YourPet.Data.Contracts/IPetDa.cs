using YourPet.Domain.Entities;

namespace YourPet.Data.Contracts
{
	public interface IPetDa : IEntityDa
	{
		Task<IEnumerable<Pet>> GetAllPetsAsync();
		Task<IEnumerable<Pet>> GetEnabledPetsAsync();
		Task<Pet> AddPetAsync(Pet pet);
		Task<Pet> UpdatePetAsync(Pet pet);
	}
}
