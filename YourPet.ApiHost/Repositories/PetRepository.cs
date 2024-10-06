using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using YourPet.ApiHost.Extensions;
using YourPet.Contracts;
using YourPet.Contracts.Repositories;
using YourPet.Data.Contracts;
using YourPet.Data.Postgres.DataAdapters;

namespace YourPet.ApiHost.Repositories
{
	public class PetRepository(ILogger<PetRepository> logger, IPetDa petDa) : IPetRepository
	{
		private readonly ILogger<PetRepository> _logger = logger;

		public async Task<PetDto> AddPetAsync(PetDto petDto, int userId)
		{
			var pet = petDto.FromDto();
			var addedPet = await petDa.AddPetAsync(pet, userId);
			return addedPet.ToDto();
		}

		public async Task<IEnumerable<PetDto>> GetAllPetsAsync(bool onlyEnabled)
		{
			IEnumerable<PetDto> pets = (await petDa.GetAllPetsAsync(onlyEnabled)).Map();
			return pets;
		}

		public async Task<PetDto> UpdatePetAsync(PetDto pet)
		{
			return (await petDa.UpdatePetAsync(pet.FromDto())).ToDto();
		}

		public async Task DeleteAsync(int id)
		{
			await petDa.DeleteAsync(id);
		}

		public async Task<IEnumerable<PetDto>> GetUserPetsAsync(int userId, bool onlyEnabled)
		{
			IEnumerable<PetDto> pets;
			pets = (await petDa.GetUserPetsAsync(userId, onlyEnabled)).Map();
			return pets;
		}

		public Task<IEnumerable<PetDto>> GetPetById(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> AssignPetToUserAsync(int petId, int userId)
		{
			return await petDa.AssignPetToUserAsync(petId, userId);
		}

		public async Task<bool> RemovePetFromUserAsync(int petId, int userId)
		{
			return await petDa.RemovePetFromUserAsync(petId, userId);
		}
	}
}
