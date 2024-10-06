namespace YourPet.Contracts.Repositories;

public interface IPetRepository : IEntityRepository
{
	Task<IEnumerable<PetDto>> GetAllPetsAsync(bool onlyEnabled);
	Task<IEnumerable<PetDto>> GetUserPetsAsync(int userId, bool onlyEnabled);
	Task<IEnumerable<PetDto>> GetPetById(int id);
	Task<PetDto> UpdatePetAsync(PetDto petDto);
	Task<PetDto> AddPetAsync(PetDto petDto, int userId);
	Task<bool> AssignPetToUserAsync(int petId, int userId);
	Task<bool> RemovePetFromUserAsync(int petId, int userId);

}