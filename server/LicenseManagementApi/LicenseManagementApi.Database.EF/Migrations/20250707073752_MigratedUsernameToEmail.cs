using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicenseManagementApi.Database.EF.Migrations
{
    /// <inheritdoc />
    public partial class MigratedUsernameToEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "user",
                newName: "email");

            migrationBuilder.RenameIndex(
                name: "IX_user_username",
                table: "user",
                newName: "IX_user_email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "user",
                newName: "username");

            migrationBuilder.RenameIndex(
                name: "IX_user_email",
                table: "user",
                newName: "IX_user_username");
        }
    }
}
