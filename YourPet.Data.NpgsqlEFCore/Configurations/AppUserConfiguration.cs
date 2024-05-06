using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using YourPet.Domain.Entities;

namespace YourPet.NpgsqlEFCore.Configurations
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder) 
        {
            builder.ToTable("app_user");
            builder.Property(p => p.DateOfBirth).HasColumnType("date");
        }
    }
}
