using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobsityChatApi.Data.Migrations
{
    public partial class ChatroomSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Chatrooms",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Chatrooms",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("35c9e3b1-6ac8-46aa-9b9f-d3a5a3ec3066"), "Just Chatting 5" },
                    { new Guid("54b58ae6-5ac7-41bd-9f7d-814dbd96d336"), "Just Chatting 4" },
                    { new Guid("b7b87834-b5ab-429f-af21-52b10526fb9b"), "Just Chatting 3" },
                    { new Guid("cddb89d0-594e-4613-b93a-f2d2693c51e2"), "Just Chatting 2" },
                    { new Guid("d9678177-5b2b-4097-b4c4-b2f90e97ca6d"), "Just Chatting 1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chatrooms_Title",
                table: "Chatrooms",
                column: "Title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chatrooms_Title",
                table: "Chatrooms");

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("35c9e3b1-6ac8-46aa-9b9f-d3a5a3ec3066"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("54b58ae6-5ac7-41bd-9f7d-814dbd96d336"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("b7b87834-b5ab-429f-af21-52b10526fb9b"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("cddb89d0-594e-4613-b93a-f2d2693c51e2"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("d9678177-5b2b-4097-b4c4-b2f90e97ca6d"));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Chatrooms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
