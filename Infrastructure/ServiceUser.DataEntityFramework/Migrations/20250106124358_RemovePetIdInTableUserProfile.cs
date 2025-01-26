using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceUser.DataEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RemovePetIdInTableUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetId",
                table: "UserProfiles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PetId",
                table: "UserProfiles",
                type: "uuid",
                nullable: true);
        }
    }
}
