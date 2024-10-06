namespace YourPet.Domain.Entities
{
	public class Event
	{
		public int ID { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public int PetID { get; set; }
		public Pet Pet { get; set; }
	}
}
