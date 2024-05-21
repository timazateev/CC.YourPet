using Microsoft.AspNetCore.Mvc;
using YourPet.Contracts;

namespace YourPet.ApiHost.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AppUserController(ILogger<AppUserController> logger, IAppUserRepository appUserRepository) : ControllerBase
	{
		private readonly ILogger<AppUserController> _logger = logger;
		private readonly IAppUserRepository _appUserRepository = appUserRepository;

		[HttpGet]
		public async Task<ActionResult<IEnumerable<AppUserDto>>> GetAllAppUsersAsync()
		{
			var appUsers = await _appUserRepository.GetAllAppUsersAsync();
			if (appUsers == null)
				return NotFound();
			return Ok(appUsers);
		}

		[HttpPost]
		public async Task<ActionResult<AppUserDto>> AddAppUserAsync(AppUserDto appUser)
		{
			try
			{
				if (appUser == null)
					return BadRequest("AppUser data is null");

				var addedUser = await _appUserRepository.AddAppUserAsync(appUser);
				return Ok(addedUser);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error adding AppUser");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpPut]
		public async Task<ActionResult<AppUserDto>> UpdateAppUserAsync(AppUserDto appUser)
		{
			try
			{
				if (appUser == null || appUser.Id == default)
					return BadRequest("AppUser data is invalid");

				var updatedAppUser = await _appUserRepository.UpdateAppUserAsync(appUser);
				return Ok(updatedAppUser);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error updating AppUser");
				return StatusCode(500, "Internal server error");
			}
		}
	}
}