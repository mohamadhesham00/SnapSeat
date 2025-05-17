using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addColumnForCheckingIfTheEventIsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "location",
                schema: "Event",
                table: "Events",
                newName: "Location");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Event",
                table: "Events",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Event",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Location",
                schema: "Event",
                table: "Events",
                newName: "location");
        }
    }
}
