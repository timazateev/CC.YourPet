using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using YourPet.Domain.Entities;

namespace YourPet.NpgsqlEFCore.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pet");
		builder.Property(p => p.DateOfBirth).HasColumnType("date");
	}
}