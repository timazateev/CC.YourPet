using Microsoft.AspNetCore.Mvc;
using YourPet.Contracts;
using YourPet.Contracts.Repositories;

namespace YourPet.ApiHost.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PetController(ILogger<PetController> logger, IPetRepository petRepository, IAppUserRepository appUserRepository) : ControllerBase
	{

		private readonly ILogger<PetController> _logger = logger;
		private readonly IPetRepository _petRepository = petRepository;
		private readonly IAppUserRepository _appuserRepository = appUserRepository;

		[HttpGet]
		public async Task<ActionResult<IEnumerable<PetDto>>> GetAllPetsAsync(bool onlyEnabled = false)
		{
			var pets = await _petRepository.GetAllPetsAsync(onlyEnabled);
			if (pets == null)
				return NotFound();
			return Ok(pets);
		}

		[HttpGet("{userId}")]
		public async Task<ActionResult<IEnumerable<PetDto>>> GetUsersPetsAsync(int userId, bool onlyEnabled = false)
		{
			var pets = await _petRepository.GetUserPetsAsync(userId, onlyEnabled);
			if (pets == null)
				return NotFound();
			return Ok(pets);
		}

		[HttpPost]
		public async Task<ActionResult<PetDto>> AddPetAsync(PetDto pet)
		{
			try
			{
				var auth0Id = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
				if (auth0Id == null)
				{
					return Unauthorized();
				}

				var user = await _appuserRepository.GetAppUserByAuth0IdOrDefaultAsync(auth0Id);
				if (user == null)
				{
					return NotFound("User not found.");
				}

				if (pet == null)
					return BadRequest("Pet data is null");

				var addedPet = await _petRepository.AddPetAsync(pet, user.Id);

				return Ok(addedPet);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error adding Pet");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpPut]
		public async Task<ActionResult<PetDto>> UpdatePetAsync(PetDto pet)
		{
			try
			{
				if (pet == null || pet.Id == default)
					return BadRequest("Pet data is invalid");

				var updatedPet = await _petRepository.UpdatePetAsync(pet);
				return Ok(updatedPet);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error updating Pet");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpPost("{petId}/assign")]
		public async Task<ActionResult> AssignPetToUserAsync(int petId, int userId)
		{
			try
			{
				var result = await _petRepository.AssignPetToUserAsync(petId, userId);
				if (!result)
					return NotFound("Either Pet or User not found");

				return Ok("Pet successfully assigned to user");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error assigning Pet to User");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpPost("{petId}/remove")]
		public async Task<ActionResult> RemovePetFromUserAsync(int petId, int userId)
		{
			try
			{
				var result = await _petRepository.RemovePetFromUserAsync(petId, userId);
				if (!result)
					return NotFound("Either Pet not found or User does not own this pet");

				return Ok("Pet successfully removed from user");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error removing Pet from User");
				return StatusCode(500, "Internal server error");
			}
		}

	}
}
