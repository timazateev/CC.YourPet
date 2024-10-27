using System.Collections.Generic;
using YourPet.ApiHost.Extensions;
using YourPet.Contracts;
using YourPet.Contracts.Repositories;
using YourPet.Data.Contracts;

namespace YourPet.ApiHost.Repositories
{
	public class PetRepository(ILogger<PetRepository> logger, IPetDa petDa) : IPetRepository
	{
		private readonly ILogger<PetRepository> _logger = logger;

		public async Task<PetDto> AddPetAsync(PetDto petDto)
		{
			Domain.Entities.Pet pet = petDto.FromDto();
			return (await petDa.AddPetAsync(pet)).ToDto();
		}

		public async Task<IEnumerable<PetDto>> GetAllPetsAsync(bool onlyEnabled)
		{
			IEnumerable<PetDto> pets;
			if (onlyEnabled)
			{
				pets = (await petDa.GetEnabledPetsAsync()).Map();
			}
			else
			{
				pets = (await petDa.GetAllPetsAsync()).Map();
			}
			return pets;
		}

		public async Task<PetDto> UpdatePetAsync(PetDto pet)
		{
			return (await petDa.UpdatePetAsync(pet.FromDto())).ToDto();
		}
	}
}
