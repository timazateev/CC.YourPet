using YourPet.Domain.Enums;

namespace YourPet.Contracts
{
	public class EventDto
	{
		public int Id { get; set; }
		public int CreatorUserId { get; set; }
		public string? Description { get; set; }
		public EventType EventType { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime StartedAt { get; set; }
		public DateTime? CompletedAt { get; set; }
		public List<int> GuestIds { get; set; } = [];
		public List<int> PetIds { get; set; } = [];
	}
}
