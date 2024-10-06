namespace YourPet.Contracts
{
	public class RegisterUserModel
	{
		public string? Auth0Id { get; set; }
		public required string FullName { get; set; }
		public string? Email { get; set; }
	}
}
