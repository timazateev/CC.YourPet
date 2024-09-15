using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourPet.NpgsqlEFCore.Migrations
{
    /// <inheritdoc />
    public partial class AvatarKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photo",
                table: "pet");

            migrationBuilder.AddColumn<string>(
                name: "avatar_key",
                table: "pet",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "avatar_key",
                table: "pet");

            migrationBuilder.AddColumn<byte[]>(
                name: "photo",
                table: "pet",
                type: "bytea",
                nullable: true);
        }
    }
}
