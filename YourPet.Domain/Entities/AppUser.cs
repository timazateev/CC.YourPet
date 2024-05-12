﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YourPet.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int Id { get; set; }
        public string? FullName { get; set; }
        public DateTime? RegistrationDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginDate { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? Bio { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public bool IsActive { get; set; } = false;

		// Связи
		public List<Pet> Pets { get; set; }
	}
}