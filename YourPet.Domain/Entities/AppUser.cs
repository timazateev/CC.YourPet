using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YourPet.Domain.Entities
{
    public class AppUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; set; }

		[Column("full_name")]
		public string? FullName { get; set; }

		[Column("registration_date")]
		public DateTime? RegistrationDate { get; set; } = DateTime.UtcNow;

		[Column("last_login_date")]
		public DateTime? LastLoginDate { get; set; }

		[Column("profile_picture_url")]
		public string? ProfilePictureUrl { get; set; }

		[Column("email")]
		public string? Email { get; set; }

		[Column("date_of_birth")]
		public DateTime? DateOfBirth { get; set; }

		[Column("address")]
		public string? Address { get; set; }

		[Column("city")]
		public string? City { get; set; }

		[Column("country")]
		public string? Country { get; set; }

		[Column("postal_code")]
		public string? PostalCode { get; set; }

		[Column("bio")]
		public string? Bio { get; set; }

		[Column("is_subscribed_to_newsletter")]
		public bool IsSubscribedToNewsletter { get; set; }

		[Column("is_active")]
		public bool IsActive { get; set; } = false;

		[Column("auth_id")]
		public string? Auth0Id { get; set; }


        [InverseProperty("Owners")]
        public List<Pet> Pets { get; set; } = [];

		[InverseProperty("Guests")]
		public List<Event> Events { get; set; } = [];
	}
}