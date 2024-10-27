using YourPet.Contracts;
using YourPet.Data.Contracts;
using YourPet.ApiHost.Extensions;
using YourPet.Contracts.Repositories;
using YourPet.Data.Postgres.DataAdapters;

namespace YourPet.ApiHost.Repositories
{
	public class EventRepository : IEventRepository
	{
		private readonly ILogger<EventRepository> _logger;
		private readonly IEventDa _eventDa;
		private readonly IAppUserDa _userDa;
		private readonly IPetDa _petDa;

		public EventRepository(ILogger<EventRepository> logger, IEventDa eventDa, IAppUserDa userDa, IPetDa petDa)
		{
			_logger = logger;
			_eventDa = eventDa;
			_userDa = userDa;
			_petDa = petDa;
		}

		public async Task<IEnumerable<EventDto>> GetAllEventsAsync(bool includePets = true)
		{
			var events = await _eventDa.GetAllEventsAsync(includePets);
			return events.Map();
		}

		public async Task<EventDto> GetEventByIdAsync(int id)
		{
			var eventEntity = await _eventDa.GetEventByIdAsync(id);
			return eventEntity?.ToDto();
		}

		public async Task<EventDto> AddEventAsync(EventDto eventDto)
		{
			var users = await _userDa.GetUsersByIds(eventDto.GuestIds);

			var pets = (await _petDa.GetPetsByIds(eventDto.PetIds));

			var eventEntity = await _eventDa.AddEventAsync(eventDto.FromDto(users, pets));
			return eventEntity.ToDto();
		}

		public async Task<EventDto> UpdateEventAsync(EventDto eventDto)
		{
			var users = (await _userDa.GetAllAppUsersAsync())
				.Where(u => eventDto.GuestIds.Contains(u.Id))
				.ToList();

			var pets = (await _petDa.GetAllPetsAsync())
							.Where(p => eventDto.GuestIds.Contains(p.Id))
							.ToList();

			var updatedEvent = await _eventDa.UpdateEventAsync(eventDto.FromDto(users, pets));
			return updatedEvent.ToDto();
		}

		public async Task<bool> DeleteEventAsync(int id)
		{
			return await _eventDa.DeleteEventAsync(id);
		}
	}
}
