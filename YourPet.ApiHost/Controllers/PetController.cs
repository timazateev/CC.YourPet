using Microsoft.AspNetCore.Mvc;
using YourPet.Contracts;

namespace YourPet.ApiHost.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PetController(ILogger<PetController> logger, IPetRepository petRepository) : ControllerBase
	{

		private readonly ILogger<PetController> _logger = logger;
		private readonly IPetRepository _petRepository = petRepository;

		[HttpGet]
		public async Task<ActionResult<IEnumerable<PetDto>>> GetAllPetsAsync()
		{
			var pets = await _petRepository.GetAllPetsAsync();
			if (pets == null) 
				return NotFound();
			return Ok(pets);
		}

		[HttpPost]
		public async Task<ActionResult<PetDto>> AddPetAsync(PetDto pet)
		{
			try
			{
				if (pet == null)
					return BadRequest("Pet data is null");

				return await _petRepository.AddPetAsync(pet);
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
	}
}
