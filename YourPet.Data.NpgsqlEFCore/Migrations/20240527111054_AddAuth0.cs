using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourPet.NpgsqlEFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddAuth0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "app_user");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "app_user");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "app_user");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "app_user");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "app_user");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "app_user");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "app_user");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "app_user");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "app_user");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "app_user");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "app_user");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "app_user");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "app_user");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "app_user");

            migrationBuilder.AddColumn<string>(
                name: "Auth0Id",
                table: "app_user",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Auth0Id",
                table: "app_user");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "app_user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "app_user",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "app_user",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "app_user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "app_user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "app_user",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "app_user",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "app_user",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "app_user",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "app_user",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "app_user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "app_user",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "app_user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "app_user",
                type: "text",
                nullable: true);
        }
    }
}
