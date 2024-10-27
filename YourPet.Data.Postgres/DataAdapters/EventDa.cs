using Microsoft.EntityFrameworkCore;
using YourPet.Data.Contracts;
using YourPet.Data.NPgsqlEfCore;
using YourPet.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace YourPet.Data.Postgres.DataAdapters
{
	public class EventDa : IEventDa
	{
		private readonly PetDbContext _context;
		private readonly ILogger<EventDa> _logger;

		public EventDa(PetDbContext context, ILogger<EventDa> logger)
		{
			_context = context;
			_logger = logger;
		}

		public async Task<IEnumerable<Event>> GetAllEventsAsync(bool includePets = true)
		{
			IQueryable<Event> query = _context.Events.Include(e => e.Guests);
			if (includePets)
				query = query.Include(e => e.Pets);

			return await query.ToListAsync();
		}

		public async Task<Event> GetEventByIdAsync(int id)
		{
			return await _context.Events
				.Include(e => e.Guests)
				.Include(e => e.Pets)
				.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task<Event> AddEventAsync(Event eventEntity)
		{
			_context.Events.Add(eventEntity);
			await _context.SaveChangesAsync();
			return eventEntity;
		}

		public async Task<Event> UpdateEventAsync(Event eventEntity)
		{
			_context.Events.Update(eventEntity);
			await _context.SaveChangesAsync();
			return eventEntity;
		}

		public async Task<bool> DeleteEventAsync(int id)
		{
			var eventEntity = await _context.Events.FindAsync(id);
			if (eventEntity == null)
				return false;

			_context.Events.Remove(eventEntity);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
