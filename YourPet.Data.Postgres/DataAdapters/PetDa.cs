﻿using YourPet.Data.Contracts;
using YourPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using YourPet.NPgsqlEfCore;

namespace YourPet.Data.Postgres.DataAdapters
{
	public class PetDa(PetDbContext context, ILogger<PetDa> logger) : IPetDa
	{
		private readonly PetDbContext _context = context;
		private readonly ILogger<PetDa> _logger = logger;

		public async Task<AppUser?> UpdateAppUserAsync(AppUser appUser)
		{
			var user = await _context.AppUsers.FirstOrDefaultAsync(u => u.Id == appUser.Id);

			if (user == null)
			{
				return null;
			}

			_context.Entry(user).CurrentValues.SetValues(appUser);
			await _context.SaveChangesAsync();

			return user;
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

		public async Task<IEnumerable<Pet>> GetAllPetsAsync(bool onlyEnabled)
		{
			var query = _context.Pets.AsQueryable();

			if (onlyEnabled)
			{
				query = query.Where(p => p.Enabled == onlyEnabled);
			}

			return await query.ToListAsync();
		}

		public async Task<IEnumerable<Pet>> GetUserPetsAsync(int userId, bool onlyEnabled)
		{
			var query = _context.Pets.AsQueryable();

			query = query.Include(p => p.Owners)
						 .Where(p => p.Owners.Any(u => u.Id == userId));

			if (onlyEnabled)
			{
				query = query.Where(p => p.Enabled);
			}

			return await query.ToListAsync();
		}


		public async Task<Pet> UpdatePetAsync(Pet pet)
		{
			_context.Pets.Update(pet);
			await _context.SaveChangesAsync();
			return pet;
		}

		public async Task<Pet> AddPetAsync(Pet pet, int userId)
		{
			_context.Pets.Add(pet);
			try
			{
				await _context.SaveChangesAsync();

				var user = await _context.AppUsers.FindAsync(userId);
				if (user != null)
				{
					user.Pets.Add(pet);
					await _context.SaveChangesAsync();
				}
			}
			catch (Exception e)
			{
				_logger.LogError("Error during pet add. Error: {Error}", e);
				throw;
			}
			return pet;
		}

		public async Task<bool> AssignPetToUserAsync(int petId, int userId)
		{
			var pet = await _context.Pets.FindAsync(petId);
			var user = await _context.AppUsers
				.Include(u => u.Pets)
				.FirstOrDefaultAsync(u => u.Id == userId);

			if (pet == null || user == null)
			{
				return false;
			}

			if (user.Pets.Any(p => p.Id == petId))
			{
				return false;
			}

			user.Pets.Add(pet);
			await _context.SaveChangesAsync();

			return true;
		}

		public async Task<bool> RemovePetFromUserAsync(int petId, int userId)
		{
			var user = await _context.AppUsers
				.Include(u => u.Pets)
				.FirstOrDefaultAsync(u => u.Id == userId);

			var pet = await _context.Pets.FindAsync(petId);

			if (user == null || pet == null)
			{
				return false;
			}

			if (!user.Pets.Any(p => p.Id == petId))
			{
				return false;
			}

			user.Pets.Remove(pet);
			await _context.SaveChangesAsync();

			return true;
		}

	}
}
