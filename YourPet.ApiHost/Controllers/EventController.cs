using Microsoft.AspNetCore.Mvc;
using YourPet.Contracts;
using YourPet.Contracts.Repositories;

namespace YourPet.ApiHost.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EventController : ControllerBase
	{
		private readonly ILogger<EventController> _logger;
		private readonly IEventRepository _eventRepository;

		public EventController(ILogger<EventController> logger, IEventRepository eventRepository)
		{
			_logger = logger;
			_eventRepository = eventRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<EventDto>>> GetAllEventsAsync(bool includePets = true)
		{
			try
			{
				var events = await _eventRepository.GetAllEventsAsync(includePets);
				if (events == null)
					return NotFound();

				return Ok(events);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error retrieving events");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<EventDto>> GetEventByIdAsync(int id)
		{
			try
			{
				var eventDto = await _eventRepository.GetEventByIdAsync(id);
				if (eventDto == null)
					return NotFound($"Event with ID {id} not found");

				return Ok(eventDto);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error retrieving event with ID {id}");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpPost]
		public async Task<ActionResult<EventDto>> AddEventAsync(EventDto eventDto)
		{
			try
			{
				if (eventDto == null)
					return BadRequest("Event data is null");

				var createdEvent = await _eventRepository.AddEventAsync(eventDto);
				return CreatedAtAction(nameof(GetEventByIdAsync), new { id = createdEvent.Id }, createdEvent);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error adding event");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpPut]
		public async Task<ActionResult<EventDto>> UpdateEventAsync(EventDto eventDto)
		{
			try
			{
				if (eventDto == null || eventDto.Id == default)
					return BadRequest("Event data is invalid");

				var updatedEvent = await _eventRepository.UpdateEventAsync(eventDto);
				if (updatedEvent == null)
					return NotFound($"Event with ID {eventDto.Id} not found");

				return Ok(updatedEvent);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error updating event");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEventAsync(int id)
		{
			try
			{
				var deleted = await _eventRepository.DeleteEventAsync(id);
				if (!deleted)
					return NotFound($"Event with ID {id} not found");

				return NoContent();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error deleting event with ID {id}");
				return StatusCode(500, "Internal server error");
			}
		}
	}
}
