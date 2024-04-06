namespace YourPet.Domain.Entities
{
	public class MedicineIntake
	{
		public int ID { get; set; }

		public DateTime IntakeTime { get; set; }

		/// <summary>
		/// Dosage for this treatment
		/// </summary>
		public string Dosage { get; set; }

		/// <summary>
		/// Notes or comments about the appointment (such as the pet's reaction or special circumstances)
		/// </summary>
		public string Notes { get; set; }

		/// <summary>
		/// Foreign key for Medicine
		/// </summary>
		public Guid MedicineID { get; set; }
		public Medicine Medicine { get; set; }

		/// <summary>
		/// Foreign key for pet
		/// </summary>
		public Guid PetID { get; set; }
		public Pet Pet { get; set; }
	}
}
