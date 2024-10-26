namespace YourPet.Contracts
{
    public class AppUserDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateTime? RegistrationDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginDate { get; set; }
        public string? ProfilePictureUrl { get; set; }
		public string? Email { get; set; }
		public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? Bio { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public bool IsActive { get; set; } = false;
		public string? Auth0Id { get; set; }
	}
}