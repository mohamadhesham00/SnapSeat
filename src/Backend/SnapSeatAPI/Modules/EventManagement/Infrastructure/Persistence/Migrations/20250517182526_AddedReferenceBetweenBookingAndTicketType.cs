using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedReferenceBetweenBookingAndTicketType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TicketTypeId",
                schema: "Event",
                table: "Bookings",
                column: "TicketTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_TicketTypes_TicketTypeId",
                schema: "Event",
                table: "Bookings",
                column: "TicketTypeId",
                principalSchema: "Event",
                principalTable: "TicketTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_TicketTypes_TicketTypeId",
                schema: "Event",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_TicketTypeId",
                schema: "Event",
                table: "Bookings");
        }
    }
}
