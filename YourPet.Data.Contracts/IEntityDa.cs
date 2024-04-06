using YourPet.Domain.Entities;

namespace YourPet.Data.Contracts;

public interface IEntityDa
{
    Task DeleteAsync(int id);
}