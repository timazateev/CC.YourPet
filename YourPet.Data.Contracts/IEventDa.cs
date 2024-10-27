using YourPet.Domain.Entities;

namespace YourPet.Data.Contracts
{
	public interface IEventDa
	{
		Task<IEnumerable<Event>> GetAllEventsAsync(bool includePets = true);
		Task<Event> GetEventByIdAsync(int id);
		Task<Event> AddEventAsync(Event eventEntity);
		Task<Event> UpdateEventAsync(Event eventEntity);
		Task<bool> DeleteEventAsync(int id);
	}
}
