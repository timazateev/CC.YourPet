﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using YourPet.Data.NPgsqlEfCore;

#nullable disable

namespace YourPet.NpgsqlEFCore.Migrations
{
    [DbContext(typeof(PetDbContext))]
    partial class PetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AppUserPet", b =>
                {
                    b.Property<string>("OwnersId")
                        .HasColumnType("text")
                        .HasColumnName("owners_id");

                    b.Property<int>("PetsId")
                        .HasColumnType("integer")
                        .HasColumnName("pets_id");

                    b.HasKey("OwnersId", "PetsId")
                        .HasName("pk_app_user_pet");

                    b.HasIndex("PetsId")
                        .HasDatabaseName("ix_app_user_pet_pets_id");

                    b.ToTable("app_user_pet", (string)null);
                });

            modelBuilder.Entity("YourPet.Domain.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Bio")
                        .HasColumnType("text")
                        .HasColumnName("bio");

                    b.Property<string>("City")
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Country")
                        .HasColumnType("text")
                        .HasColumnName("country");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("email_confirmed");

                    b.Property<string>("FullName")
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<bool>("IsSubscribedToNewsletter")
                        .HasColumnType("boolean")
                        .HasColumnName("is_subscribed_to_newsletter");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_login_date");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text")
                        .HasColumnName("normalized_user_name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("PostalCode")
                        .HasColumnType("text")
                        .HasColumnName("postal_code");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("text")
                        .HasColumnName("profile_picture_url");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("registration_date");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_app_user");

                    b.ToTable("app_user", (string)null);
                });

            modelBuilder.Entity("YourPet.Domain.Entities.Event", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("PetID")
                        .HasColumnType("integer")
                        .HasColumnName("pet_id");

                    b.HasKey("ID")
                        .HasName("pk_event");

                    b.HasIndex("PetID")
                        .HasDatabaseName("ix_event_pet_id");

                    b.ToTable("event", (string)null);
                });

            modelBuilder.Entity("YourPet.Domain.Entities.Medicine", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Dosage")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("dosage");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("PetID")
                        .HasColumnType("integer")
                        .HasColumnName("pet_id");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.HasKey("ID")
                        .HasName("pk_medicine");

                    b.HasIndex("PetID")
                        .HasDatabaseName("ix_medicine_pet_id");

                    b.ToTable("medicine", (string)null);
                });

            modelBuilder.Entity("YourPet.Domain.Entities.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BehaviorNotes")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("behavior_notes");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("breed");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("color");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("DietaryRequirements")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("dietary_requirements");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("gender");

                    b.Property<string>("MedicalHistory")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("medical_history");

                    b.Property<string>("MicrochipID")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("microchip_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("photo");

                    b.Property<string>("SpecialNeeds")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("special_needs");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("species");

                    b.Property<string>("VaccinationRecords")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("vaccination_records");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision")
                        .HasColumnName("weight");

                    b.HasKey("Id")
                        .HasName("pk_pet");

                    b.ToTable("pet", (string)null);
                });

            modelBuilder.Entity("AppUserPet", b =>
                {
                    b.HasOne("YourPet.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("OwnersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_app_user_pet_app_user_owners_id");

                    b.HasOne("YourPet.Domain.Entities.Pet", null)
                        .WithMany()
                        .HasForeignKey("PetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_app_user_pet_pets_pets_id");
                });

            modelBuilder.Entity("YourPet.Domain.Entities.Event", b =>
                {
                    b.HasOne("YourPet.Domain.Entities.Pet", "Pet")
                        .WithMany("Events")
                        .HasForeignKey("PetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_event_pets_pet_id");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("YourPet.Domain.Entities.Medicine", b =>
                {
                    b.HasOne("YourPet.Domain.Entities.Pet", "Pet")
                        .WithMany("Medicines")
                        .HasForeignKey("PetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_medicine_pets_pet_id");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("YourPet.Domain.Entities.Pet", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Medicines");
                });
#pragma warning restore 612, 618
        }
    }
}
