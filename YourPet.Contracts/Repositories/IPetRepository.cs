namespace YourPet.Contracts.Repositories;

public interface IPetRepository
{
	Task<IEnumerable<PetDto>> GetAllPetsAsync(bool onlyEnabled);
	Task<PetDto> AddPetAsync(PetDto account);
	Task<PetDto> UpdatePetAsync(PetDto account);
}