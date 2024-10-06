namespace YourPet.Domain.Entities
{
	public class Medicine
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Dosage { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int PetID { get; set; }
		public Pet Pet { get; set; }
	}
}
