using YourPet.Data.Contracts;
using YourPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using YourPet.Data.NPgsqlEfCore;
using Microsoft.Extensions.Logging;

namespace YourPet.Data.Postgres.DataAdapters
{
	public class PetDa : IPetDa
	{
		private readonly PetDbContext _context;
		private readonly ILogger<PetDa> _logger;

		public PetDa(PetDbContext context, ILogger<PetDa> logger)
		{
			_context = context;
			_logger = logger;
		}

		public async Task<Pet> AddPetAsync(Pet pet)
		{
			_context.Pets.Add(pet);
			try
			{
			await _context.SaveChangesAsync();
			}
			catch (Exception e)
			{
				_logger.LogError("Error during pet add. Error: {Error}", e);
				throw;
			}
			return pet;
		}

		public async Task DeleteAsync(int id)
		{
			var pet = await _context.Pets.FindAsync(id);
			if (pet != null)
			{
				_context.Pets.Remove(pet);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Pet>> GetAllPetsAsync()
		{
			return await _context.Pets.ToListAsync();
		}

		public async Task<IEnumerable<Pet>> GetEnabledPetsAsync()
		{
			return await _context.Pets.Where(p => p.Enabled).ToListAsync();
		}

		public async Task<Pet> UpdatePetAsync(Pet pet)
		{
			_context.Pets.Update(pet);
			await _context.SaveChangesAsync();
			return pet;
		}
	}
}