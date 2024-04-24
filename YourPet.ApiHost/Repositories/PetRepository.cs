﻿using YourPet.ApiHost.Extensions;
using YourPet.Contracts;
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

		public async Task<IEnumerable<PetDto>> GetAllPetsAsync()
		{
			return (await petDa.GetAllPetsAsync()).Map();
		}

		public async Task<PetDto> UpdatePetAsync(PetDto pet)
		{
			return (await petDa.UpdatePetAsync(pet.FromDto())).ToDto();
		}

		public async Task DeleteAsync(int id)
		{
			await petDa.DeleteAsync(id);
		}
	}
}