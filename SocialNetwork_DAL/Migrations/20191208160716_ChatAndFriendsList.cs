using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork_DAL.Migrations
{
    public partial class ChatAndFriendsList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuoChat",
                columns: table => new
                {
                    ChatId = table.Column<Guid>(nullable: false),
                    PersonId1 = table.Column<Guid>(nullable: false),
                    PersonId2 = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuoChat", x => x.ChatId);
                });

            migrationBuilder.CreateTable(
                name: "Friend",
                columns: table => new
                {
                    FriendId = table.Column<Guid>(nullable: false),
                    Friend_Login = table.Column<string>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend", x => x.FriendId);
                    table.ForeignKey(
                        name: "FK_Friend_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invite",
                columns: table => new
                {
                    InviteId = table.Column<Guid>(nullable: false),
                    Inviter_Login = table.Column<string>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invite", x => x.InviteId);
                    table.ForeignKey(
                        name: "FK_Invite_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageId = table.Column<Guid>(nullable: false),
                    Message_Data = table.Column<string>(nullable: true),
                    DuoChatId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Message_DuoChat_DuoChatId",
                        column: x => x.DuoChatId,
                        principalTable: "DuoChat",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friend_PersonId",
                table: "Friend",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Invite_PersonId",
                table: "Invite",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_DuoChatId",
                table: "Message",
                column: "DuoChatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friend");

            migrationBuilder.DropTable(
                name: "Invite");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "DuoChat");
        }
    }
}
