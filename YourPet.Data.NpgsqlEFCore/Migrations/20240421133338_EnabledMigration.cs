using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourPet.NpgsqlEFCore.Migrations
{
    /// <inheritdoc />
    public partial class EnabledMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_app_user_pet_app_user_owners_id",
                table: "app_user_pet");

            migrationBuilder.DropForeignKey(
                name: "fk_app_user_pet_pets_pets_id",
                table: "app_user_pet");

            migrationBuilder.DropForeignKey(
                name: "fk_event_pets_pet_id",
                table: "event");

            migrationBuilder.DropForeignKey(
                name: "fk_medicine_pets_pet_id",
                table: "medicine");

            migrationBuilder.DropPrimaryKey(
                name: "pk_pet",
                table: "pet");

            migrationBuilder.DropPrimaryKey(
                name: "pk_medicine",
                table: "medicine");

            migrationBuilder.DropPrimaryKey(
                name: "pk_event",
                table: "event");

            migrationBuilder.DropPrimaryKey(
                name: "pk_app_user_pet",
                table: "app_user_pet");

            migrationBuilder.DropPrimaryKey(
                name: "pk_app_user",
                table: "app_user");

            migrationBuilder.RenameTable(
                name: "medicine",
                newName: "Medicine");

            migrationBuilder.RenameTable(
                name: "event",
                newName: "Event");

            migrationBuilder.RenameTable(
                name: "app_user_pet",
                newName: "AppUserPet");

            migrationBuilder.RenameTable(
                name: "app_user",
                newName: "AppUser");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Medicine",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "dosage",
                table: "Medicine",
                newName: "Dosage");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Medicine",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "Medicine",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "pet_id",
                table: "Medicine",
                newName: "PetID");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "Medicine",
                newName: "EndDate");

            migrationBuilder.RenameIndex(
                name: "ix_medicine_pet_id",
                table: "Medicine",
                newName: "IX_Medicine_PetID");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Event",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Event",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Event",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "pet_id",
                table: "Event",
                newName: "PetID");

            migrationBuilder.RenameIndex(
                name: "ix_event_pet_id",
                table: "Event",
                newName: "IX_Event_PetID");

            migrationBuilder.RenameColumn(
                name: "pets_id",
                table: "AppUserPet",
                newName: "PetsId");

            migrationBuilder.RenameColumn(
                name: "owners_id",
                table: "AppUserPet",
                newName: "OwnersId");

            migrationBuilder.RenameIndex(
                name: "ix_app_user_pet_pets_id",
                table: "AppUserPet",
                newName: "IX_AppUserPet_PetsId");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "AppUser",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "AppUser",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "AppUser",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "bio",
                table: "AppUser",
                newName: "Bio");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "AppUser",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AppUser",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "AppUser",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "two_factor_enabled",
                table: "AppUser",
                newName: "TwoFactorEnabled");

            migrationBuilder.RenameColumn(
                name: "security_stamp",
                table: "AppUser",
                newName: "SecurityStamp");

            migrationBuilder.RenameColumn(
                name: "registration_date",
                table: "AppUser",
                newName: "RegistrationDate");

            migrationBuilder.RenameColumn(
                name: "profile_picture_url",
                table: "AppUser",
                newName: "ProfilePictureUrl");

            migrationBuilder.RenameColumn(
                name: "postal_code",
                table: "AppUser",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "phone_number_confirmed",
                table: "AppUser",
                newName: "PhoneNumberConfirmed");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "AppUser",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "AppUser",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "normalized_user_name",
                table: "AppUser",
                newName: "NormalizedUserName");

            migrationBuilder.RenameColumn(
                name: "normalized_email",
                table: "AppUser",
                newName: "NormalizedEmail");

            migrationBuilder.RenameColumn(
                name: "lockout_end",
                table: "AppUser",
                newName: "LockoutEnd");

            migrationBuilder.RenameColumn(
                name: "lockout_enabled",
                table: "AppUser",
                newName: "LockoutEnabled");

            migrationBuilder.RenameColumn(
                name: "last_login_date",
                table: "AppUser",
                newName: "LastLoginDate");

            migrationBuilder.RenameColumn(
                name: "is_subscribed_to_newsletter",
                table: "AppUser",
                newName: "IsSubscribedToNewsletter");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "AppUser",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "AppUser",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "email_confirmed",
                table: "AppUser",
                newName: "EmailConfirmed");

            migrationBuilder.RenameColumn(
                name: "date_of_birth",
                table: "AppUser",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "concurrency_stamp",
                table: "AppUser",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "access_failed_count",
                table: "AppUser",
                newName: "AccessFailedCount");

            migrationBuilder.AlterColumn<double>(
                name: "weight",
                table: "pet",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<byte[]>(
                name: "photo",
                table: "pet",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_of_birth",
                table: "pet",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                table: "pet",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_pet",
                table: "pet",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicine",
                table: "Medicine",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserPet",
                table: "AppUserPet",
                columns: new[] { "OwnersId", "PetsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserPet_AppUser_OwnersId",
                table: "AppUserPet",
                column: "OwnersId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserPet_pet_PetsId",
                table: "AppUserPet",
                column: "PetsId",
                principalTable: "pet",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_pet_PetID",
                table: "Event",
                column: "PetID",
                principalTable: "pet",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_pet_PetID",
                table: "Medicine",
                column: "PetID",
                principalTable: "pet",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserPet_AppUser_OwnersId",
                table: "AppUserPet");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserPet_pet_PetsId",
                table: "AppUserPet");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_pet_PetID",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_pet_PetID",
                table: "Medicine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pet",
                table: "pet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicine",
                table: "Medicine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserPet",
                table: "AppUserPet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "enabled",
                table: "pet");

            migrationBuilder.RenameTable(
                name: "Medicine",
                newName: "medicine");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "event");

            migrationBuilder.RenameTable(
                name: "AppUserPet",
                newName: "app_user_pet");

            migrationBuilder.RenameTable(
                name: "AppUser",
                newName: "app_user");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "medicine",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Dosage",
                table: "medicine",
                newName: "dosage");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "medicine",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "medicine",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "PetID",
                table: "medicine",
                newName: "pet_id");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "medicine",
                newName: "end_date");

            migrationBuilder.RenameIndex(
                name: "IX_Medicine_PetID",
                table: "medicine",
                newName: "ix_medicine_pet_id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "event",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "event",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "event",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PetID",
                table: "event",
                newName: "pet_id");

            migrationBuilder.RenameIndex(
                name: "IX_Event_PetID",
                table: "event",
                newName: "ix_event_pet_id");

            migrationBuilder.RenameColumn(
                name: "PetsId",
                table: "app_user_pet",
                newName: "pets_id");

            migrationBuilder.RenameColumn(
                name: "OwnersId",
                table: "app_user_pet",
                newName: "owners_id");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserPet_PetsId",
                table: "app_user_pet",
                newName: "ix_app_user_pet_pets_id");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "app_user",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "app_user",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "app_user",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Bio",
                table: "app_user",
                newName: "bio");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "app_user",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "app_user",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "app_user",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "TwoFactorEnabled",
                table: "app_user",
                newName: "two_factor_enabled");

            migrationBuilder.RenameColumn(
                name: "SecurityStamp",
                table: "app_user",
                newName: "security_stamp");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "app_user",
                newName: "registration_date");

            migrationBuilder.RenameColumn(
                name: "ProfilePictureUrl",
                table: "app_user",
                newName: "profile_picture_url");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "app_user",
                newName: "postal_code");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberConfirmed",
                table: "app_user",
                newName: "phone_number_confirmed");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "app_user",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "app_user",
                newName: "password_hash");

            migrationBuilder.RenameColumn(
                name: "NormalizedUserName",
                table: "app_user",
                newName: "normalized_user_name");

            migrationBuilder.RenameColumn(
                name: "NormalizedEmail",
                table: "app_user",
                newName: "normalized_email");

            migrationBuilder.RenameColumn(
                name: "LockoutEnd",
                table: "app_user",
                newName: "lockout_end");

            migrationBuilder.RenameColumn(
                name: "LockoutEnabled",
                table: "app_user",
                newName: "lockout_enabled");

            migrationBuilder.RenameColumn(
                name: "LastLoginDate",
                table: "app_user",
                newName: "last_login_date");

            migrationBuilder.RenameColumn(
                name: "IsSubscribedToNewsletter",
                table: "app_user",
                newName: "is_subscribed_to_newsletter");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "app_user",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "app_user",
                newName: "full_name");

            migrationBuilder.RenameColumn(
                name: "EmailConfirmed",
                table: "app_user",
                newName: "email_confirmed");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "app_user",
                newName: "date_of_birth");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                table: "app_user",
                newName: "concurrency_stamp");

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                table: "app_user",
                newName: "access_failed_count");

            migrationBuilder.AlterColumn<double>(
                name: "weight",
                table: "pet",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "photo",
                table: "pet",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_of_birth",
                table: "pet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_pet",
                table: "pet",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_medicine",
                table: "medicine",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_event",
                table: "event",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_app_user_pet",
                table: "app_user_pet",
                columns: new[] { "owners_id", "pets_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_app_user",
                table: "app_user",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_app_user_pet_app_user_owners_id",
                table: "app_user_pet",
                column: "owners_id",
                principalTable: "app_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_app_user_pet_pets_pets_id",
                table: "app_user_pet",
                column: "pets_id",
                principalTable: "pet",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_event_pets_pet_id",
                table: "event",
                column: "pet_id",
                principalTable: "pet",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_medicine_pets_pet_id",
                table: "medicine",
                column: "pet_id",
                principalTable: "pet",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
