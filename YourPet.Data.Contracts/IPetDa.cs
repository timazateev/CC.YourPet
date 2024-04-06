using YourPet.Domain.Entities;

namespace YourPet.Data.Contracts
{
	public interface IPetDa : IEntityDa
	{
		Task<IEnumerable<Pet>> GetAllPetsAsync();
		Task<Pet> AddPetAsync(Pet pet);
		Task<Pet> UpdatePetAsync(Pet pet);
	}
}
