using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork_DAL.Migrations
{
    public partial class ChangeDuoChat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonId1",
                table: "DuoChat");

            migrationBuilder.DropColumn(
                name: "PersonId2",
                table: "DuoChat");

            migrationBuilder.AddColumn<string>(
                name: "PersonLogin1",
                table: "DuoChat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonLogin2",
                table: "DuoChat",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonLogin1",
                table: "DuoChat");

            migrationBuilder.DropColumn(
                name: "PersonLogin2",
                table: "DuoChat");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId1",
                table: "DuoChat",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId2",
                table: "DuoChat",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
