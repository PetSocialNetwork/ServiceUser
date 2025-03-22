using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceUser.DataEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddAboutselfAndInterestsInUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutSelf",
                table: "UserProfiles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                table: "UserProfiles",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutSelf",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Interests",
                table: "UserProfiles");
        }
    }
}
