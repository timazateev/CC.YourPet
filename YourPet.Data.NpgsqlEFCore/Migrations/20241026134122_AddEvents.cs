using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourPet.NpgsqlEFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_pet_PetID",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_PetID",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "event");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "event",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "event",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PetID",
                table: "event",
                newName: "event_type");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "event",
                newName: "started_at");

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
                name: "DateOfBirth",
                table: "app_user",
                newName: "date_of_birth");

            migrationBuilder.RenameColumn(
                name: "Auth0Id",
                table: "app_user",
                newName: "auth_id");

            migrationBuilder.AlterColumn<string>(
                name: "vaccination_records",
                table: "pet",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "species",
                table: "pet",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "special_needs",
                table: "pet",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "microchip_id",
                table: "pet",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "medical_history",
                table: "pet",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "pet",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "dietary_requirements",
                table: "pet",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "color",
                table: "pet",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "breed",
                table: "pet",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "behavior_notes",
                table: "pet",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "event",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "completed_at",
                table: "event",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "event",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "creator_user_id",
                table: "event",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "auth_id",
                table: "app_user",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_event",
                table: "event",
                column: "id");

            migrationBuilder.CreateTable(
                name: "AppUserEvent",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "integer", nullable: false),
                    GuestsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserEvent", x => new { x.EventsId, x.GuestsId });
                    table.ForeignKey(
                        name: "FK_AppUserEvent_app_user_GuestsId",
                        column: x => x.GuestsId,
                        principalTable: "app_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserEvent_event_EventsId",
                        column: x => x.EventsId,
                        principalTable: "event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventPet",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "integer", nullable: false),
                    PetsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPet", x => new { x.EventsId, x.PetsId });
                    table.ForeignKey(
                        name: "FK_EventPet_event_EventsId",
                        column: x => x.EventsId,
                        principalTable: "event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventPet_pet_PetsId",
                        column: x => x.PetsId,
                        principalTable: "pet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserEvent_GuestsId",
                table: "AppUserEvent",
                column: "GuestsId");

            migrationBuilder.CreateIndex(
                name: "IX_EventPet_PetsId",
                table: "EventPet",
                column: "PetsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserEvent");

            migrationBuilder.DropTable(
                name: "EventPet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_event",
                table: "event");

            migrationBuilder.DropColumn(
                name: "completed_at",
                table: "event");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "event");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                table: "event");

            migrationBuilder.RenameTable(
                name: "event",
                newName: "Event");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Event",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Event",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "started_at",
                table: "Event",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "event_type",
                table: "Event",
                newName: "PetID");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "app_user",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "app_user",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "app_user",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "bio",
                table: "app_user",
                newName: "Bio");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "app_user",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "app_user",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "registration_date",
                table: "app_user",
                newName: "RegistrationDate");

            migrationBuilder.RenameColumn(
                name: "profile_picture_url",
                table: "app_user",
                newName: "ProfilePictureUrl");

            migrationBuilder.RenameColumn(
                name: "postal_code",
                table: "app_user",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "last_login_date",
                table: "app_user",
                newName: "LastLoginDate");

            migrationBuilder.RenameColumn(
                name: "is_subscribed_to_newsletter",
                table: "app_user",
                newName: "IsSubscribedToNewsletter");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "app_user",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "app_user",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "date_of_birth",
                table: "app_user",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "auth_id",
                table: "app_user",
                newName: "Auth0Id");

            migrationBuilder.AlterColumn<string>(
                name: "vaccination_records",
                table: "pet",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "species",
                table: "pet",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "special_needs",
                table: "pet",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "microchip_id",
                table: "pet",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "medical_history",
                table: "pet",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "pet",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "dietary_requirements",
                table: "pet",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "color",
                table: "pet",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "breed",
                table: "pet",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "behavior_notes",
                table: "pet",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Event",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Auth0Id",
                table: "app_user",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_PetID",
                table: "Event",
                column: "PetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_pet_PetID",
                table: "Event",
                column: "PetID",
                principalTable: "pet",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
