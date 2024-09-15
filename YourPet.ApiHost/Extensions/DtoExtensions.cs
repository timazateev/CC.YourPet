using YourPet.Contracts;
using YourPet.Domain.Entities;

namespace YourPet.ApiHost.Extensions;

public static class DtoExtensions
{
	public static AppUser FromDto(this AppUserDto dto)
	{
		return new AppUser
		{
			Id = dto.Id,
			FullName = dto.FullName,
			RegistrationDate = dto.RegistrationDate,
			LastLoginDate = dto.LastLoginDate,
			ProfilePictureUrl = dto.ProfilePictureUrl,
			Email = dto.Email,
			DateOfBirth = dto.DateOfBirth,
			Address = dto.Address,
			City = dto.City,
			Country = dto.Country,
			PostalCode = dto.PostalCode,
			Bio = dto.Bio,
			IsSubscribedToNewsletter = dto.IsSubscribedToNewsletter,
			IsActive = dto.IsActive,
			Auth0Id = dto.Auth0Id,
		};
	}

	public static AppUserDto ToDto(this AppUser appUser)
	{
		return new AppUserDto
		{
            Id = appUser.Id,
            FullName = appUser.FullName,
            RegistrationDate = appUser.RegistrationDate,
            LastLoginDate = appUser.LastLoginDate,
            ProfilePictureUrl = appUser.ProfilePictureUrl,
			Email = appUser.Email,
			DateOfBirth = appUser.DateOfBirth,
            Address = appUser.Address,
            City = appUser.City,
            Country = appUser.Country,
            PostalCode = appUser.PostalCode,
            Bio = appUser.Bio,
            IsSubscribedToNewsletter = appUser.IsSubscribedToNewsletter,
            IsActive = appUser.IsActive,
			Auth0Id = appUser.Auth0Id,
        };
	}

	public static Pet FromDto(this PetDto dto)
	{
		return new Pet
		{
			Id = dto.Id,
			Name = dto.Name,
			Species = dto.Species,
			Breed = dto.Breed,
			DateOfBirth = dto.DateOfBirth,
			Gender = dto.Gender,
			Color = dto.Color,
			Weight = dto.Weight,
			MicrochipID = dto.MicrochipID,
			VaccinationRecords = dto.VaccinationRecords,
			MedicalHistory = dto.MedicalHistory,
			AvatarKey = dto.AvatarKey,
			SpecialNeeds = dto.SpecialNeeds,
			DietaryRequirements = dto.DietaryRequirements,
			BehaviorNotes = dto.BehaviorNotes,
			Enabled = dto.Enabled,
			// Assuming Owners, Events, Medicines are managed separately or not needed for DTO conversion
		};
	}

	public static PetDto ToDto(this Pet pet)
	{
		return new PetDto
		{
			Id = pet.Id,
			Name = pet.Name,
			Species = pet.Species,
			Breed = pet.Breed,
			DateOfBirth = pet.DateOfBirth,
			Gender = pet.Gender,
			Color = pet.Color,
			Weight = pet.Weight,
			MicrochipID = pet.MicrochipID,
			VaccinationRecords = pet.VaccinationRecords,
			MedicalHistory = pet.MedicalHistory,
			AvatarKey = pet.AvatarKey,
			SpecialNeeds = pet.SpecialNeeds,
			DietaryRequirements = pet.DietaryRequirements,
			BehaviorNotes = pet.BehaviorNotes,
			Enabled = pet.Enabled,
			// If Owners, Events, Medicines are to be included, they would need to be mapped to their respective DTOs
		};
	}

	public static IEnumerable<PetDto> Map(this IEnumerable<Pet> pets) =>
		pets.Select(pet => pet.ToDto());
    public static IEnumerable<AppUserDto> Map(this IEnumerable<AppUser> appUser) =>
        appUser.Select(appUser => appUser.ToDto());
}