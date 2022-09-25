using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Events.Data.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Events_EventId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Organizers_OrganizerId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Speeches_Speakers_SpeakerId",
                table: "Speeches");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_OrganizerId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "OrganizerId",
                table: "Addresses");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpeakerId",
                table: "Speeches",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Events_EventId",
                table: "Addresses",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Speeches_Speakers_SpeakerId",
                table: "Speeches",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Events_EventId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Speeches_Speakers_SpeakerId",
                table: "Speeches");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpeakerId",
                table: "Speeches",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizerId",
                table: "Addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_OrganizerId",
                table: "Addresses",
                column: "OrganizerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Events_EventId",
                table: "Addresses",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Organizers_OrganizerId",
                table: "Addresses",
                column: "OrganizerId",
                principalTable: "Organizers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Speeches_Speakers_SpeakerId",
                table: "Speeches",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
