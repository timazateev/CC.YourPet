namespace YourPet.Contracts;

public interface IPetRepository : IEntityRepository
{
    Task<IEnumerable<PetDto>> GetAllPetsAsync(bool onlyEnabled);
    Task<PetDto> AddPetAsync(PetDto account);
    Task<PetDto> UpdatePetAsync(PetDto account);
}