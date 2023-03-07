using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatingApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password_hash",
                table: "user");

            migrationBuilder.DropColumn(
                name: "password_salt",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "user",
                newName: "username");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "user",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "user",
                newName: "user_name");

            migrationBuilder.AddColumn<byte[]>(
                name: "password_hash",
                table: "user",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "password_salt",
                table: "user",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
