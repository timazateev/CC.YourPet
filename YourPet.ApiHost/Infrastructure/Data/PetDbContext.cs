using Microsoft.EntityFrameworkCore;
using YourPet.Domain.Entities;

namespace YourPet.ApiHost.Infrastructure
{
	public class PetDbContext : DbContext
	{
		public PetDbContext(DbContextOptions<PetDbContext> options)
			: base(options)
		{
		}

		// Define DbSets for your entities
		 public DbSet<Pet> Pet { get; set; }
		 public DbSet<AppUser> AppUser { get; set; }
		 public DbSet<Event> Event { get; set; }
		 public DbSet<Medicine> Medicine { get; set; }
		 public DbSet<MedicineIntake> MedicineIntake { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			// Model configuration
		}
	}
}