using System.ComponentModel.DataAnnotations.Schema;
using YourPet.Domain.Enums;

namespace YourPet.Domain.Entities
{
	public class Event
	{
		[Column("id")]
		public int Id { get; set; }

		[Column("creator_user_id")]
		public int CreatorUserId { get; set; }

		[Column("description")]
		public string? Description { get; set; }

		[Column("event_type")]
		public EventType EventType { get; set; }

		[Column("created_at")]
		public DateTime CreatedAt { get; set; }

		[Column("started_at")]
		public DateTime StartedAt { get; set; }

		[Column("completed_at")]
		public DateTime? CompletedAt { get; set; }

		[Column("guests")]
		public List<AppUser> Guests { get; set; } = [];

		[Column("pets")]
		public List<Pet> Pets { get; set; } = [];
	}
}
