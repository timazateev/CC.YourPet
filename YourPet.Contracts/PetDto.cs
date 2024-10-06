namespace YourPet.Contracts
{
	public class PetDto
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public string? Species { get; set; }
		public string? Breed { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string? Gender { get; set; }
		public string? Color { get; set; }
		public double? Weight { get; set; } = 0;
		public string? MicrochipID { get; set; }
		public string? VaccinationRecords { get; set; }
		public string? MedicalHistory { get; set; }
		public string? AvatarKey { get; set; }
		public string? SpecialNeeds { get; set; }
		public string? DietaryRequirements { get; set; }
		public string? BehaviorNotes { get; set; }
		public bool Enabled { get; set; } = true;
    }
}
