using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Events.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventEntityOrganizerEntity");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Organizers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Organizers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizerId",
                table: "Events",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizerId",
                table: "Events",
                column: "OrganizerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events",
                column: "OrganizerId",
                principalTable: "Organizers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_OrganizerId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "OrganizerId",
                table: "Events");

            migrationBuilder.CreateTable(
                name: "EventEntityOrganizerEntity",
                columns: table => new
                {
                    EventsId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEntityOrganizerEntity", x => new { x.EventsId, x.OrganizersId });
                    table.ForeignKey(
                        name: "FK_EventEntityOrganizerEntity_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventEntityOrganizerEntity_Organizers_OrganizersId",
                        column: x => x.OrganizersId,
                        principalTable: "Organizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventEntityOrganizerEntity_OrganizersId",
                table: "EventEntityOrganizerEntity",
                column: "OrganizersId");
        }
    }
}
