using YourPet.Contracts;
using YourPet.Domain.Entities;

namespace YourPet.ApiHost.Extensions;

public static class DtoExtensions
{
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
			Photo = dto.Photo,
			SpecialNeeds = dto.SpecialNeeds,
			DietaryRequirements = dto.DietaryRequirements,
			BehaviorNotes = dto.BehaviorNotes,
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
			Photo = pet.Photo,
			SpecialNeeds = pet.SpecialNeeds,
			DietaryRequirements = pet.DietaryRequirements,
			BehaviorNotes = pet.BehaviorNotes,
			// If Owners, Events, Medicines are to be included, they would need to be mapped to their respective DTOs
		};
	}

	public static IEnumerable<PetDto> Map(this IEnumerable<Pet> pets) =>
		pets.Select(pet => pet.ToDto());
}