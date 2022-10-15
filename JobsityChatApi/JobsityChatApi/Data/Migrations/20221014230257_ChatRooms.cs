using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobsityChatApi.Data.Migrations
{
    public partial class ChatRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SourceId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Chatrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chatrooms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SourceId",
                table: "Messages",
                column: "SourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chatrooms_SourceId",
                table: "Messages",
                column: "SourceId",
                principalTable: "Chatrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chatrooms_SourceId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Chatrooms");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SourceId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "Messages");
        }
    }
}
