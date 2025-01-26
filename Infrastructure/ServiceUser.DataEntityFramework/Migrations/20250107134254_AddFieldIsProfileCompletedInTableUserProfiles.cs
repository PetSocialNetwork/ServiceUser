using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceUser.DataEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldIsProfileCompletedInTableUserProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsProfileCompleted",
                table: "UserProfiles",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProfileCompleted",
                table: "UserProfiles");
        }
    }
}
