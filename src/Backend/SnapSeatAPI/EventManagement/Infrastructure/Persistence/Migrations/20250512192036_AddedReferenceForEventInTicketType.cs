using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedReferenceForEventInTicketType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketTypes_Events_EventId",
                schema: "Event",
                table: "TicketTypes");

            migrationBuilder.AlterColumn<Guid>(
                name: "EventId",
                schema: "Event",
                table: "TicketTypes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTypes_Events_EventId",
                schema: "Event",
                table: "TicketTypes",
                column: "EventId",
                principalSchema: "Event",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketTypes_Events_EventId",
                schema: "Event",
                table: "TicketTypes");

            migrationBuilder.AlterColumn<Guid>(
                name: "EventId",
                schema: "Event",
                table: "TicketTypes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTypes_Events_EventId",
                schema: "Event",
                table: "TicketTypes",
                column: "EventId",
                principalSchema: "Event",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
