using System.ComponentModel.DataAnnotations.Schema;

namespace YourPet.Domain.Entities
{
	/// <summary>
	/// pet entity
	/// </summary>
	public class Pet
	{
		[Column("id")]
		public int Id { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("species")]
		public string Species { get; set; }

		[Column("breed")]
		public string Breed { get; set; }

		[Column("date_of_birth")]
		public DateTime? DateOfBirth { get; set; }

		[Column("gender")]
		public string Gender { get; set; }

		[Column("color")]
		public string Color { get; set; }

		[Column("weight")]
		public double? Weight { get; set; }

		[Column("microchip_id")]
		public string MicrochipID { get; set; }

		[Column("vaccination_records")]
		public string VaccinationRecords { get; set; }

		[Column("medical_history")]
		public string MedicalHistory { get; set; }

		[Column("photo")]
		public byte[]? Photo { get; set; }

		[Column("special_needs")]
		public string SpecialNeeds { get; set; }

		[Column("dietary_requirements")]
		public string DietaryRequirements { get; set; }

		[Column("behavior_notes")]
		public string BehaviorNotes { get; set; }

		// Relationships
		// Note: For navigation properties, EF Core does not use Column attributes
		// However, you might need to configure the relationship mappings using Fluent API if the default conventions do not match your database schema
		public List<AppUser> Owners { get; set; }
		public List<Event> Events { get; set; }
		public List<Medicine> Medicines { get; set; }
	}
}