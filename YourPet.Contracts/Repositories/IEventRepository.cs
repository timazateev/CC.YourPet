namespace YourPet.Contracts.Repositories
{
	public interface IEventRepository
	{
		Task<IEnumerable<EventDto>> GetAllEventsAsync(bool includePets = true);
		Task<EventDto> GetEventByIdAsync(int id);
		Task<EventDto> AddEventAsync(EventDto eventDto);
		Task<EventDto> UpdateEventAsync(EventDto eventDto);
		Task<bool> DeleteEventAsync(int id);
	}
}
