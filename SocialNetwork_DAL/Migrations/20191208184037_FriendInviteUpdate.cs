using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork_DAL.Migrations
{
    public partial class FriendInviteUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Friend_Login",
                table: "Friend");

            migrationBuilder.AddColumn<string>(
                name: "Invited_Login",
                table: "Invite",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Friend1_Login",
                table: "Friend",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Friend2_Login",
                table: "Friend",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Invited_Login",
                table: "Invite");

            migrationBuilder.DropColumn(
                name: "Friend1_Login",
                table: "Friend");

            migrationBuilder.DropColumn(
                name: "Friend2_Login",
                table: "Friend");

            migrationBuilder.AddColumn<string>(
                name: "Friend_Login",
                table: "Friend",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
