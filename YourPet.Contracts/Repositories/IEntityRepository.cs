namespace YourPet.Contracts;

public interface IEntityRepository
{
    Task DeleteAsync(int id);
}