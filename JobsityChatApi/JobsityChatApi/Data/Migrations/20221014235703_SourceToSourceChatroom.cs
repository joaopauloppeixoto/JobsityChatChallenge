using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobsityApi.Data.Migrations
{
    public partial class SourceToSourceChatroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chatrooms_SourceId",
                table: "Messages");

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

            migrationBuilder.RenameColumn(
                name: "SourceId",
                table: "Messages",
                newName: "SourceChatroomId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SourceId",
                table: "Messages",
                newName: "IX_Messages_SourceChatroomId");

            migrationBuilder.InsertData(
                table: "Chatrooms",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("29eb3138-07b0-4565-a3db-e9d4c113cbcc"), "Just Chatting 4" },
                    { new Guid("730ff058-1b92-4130-b6c3-60dd7f1408f5"), "Just Chatting 2" },
                    { new Guid("7ec0f18e-63da-4509-b4d8-447c5fcebc75"), "Just Chatting 1" },
                    { new Guid("8446e302-50fe-4547-bdb3-d084deaddc1a"), "Just Chatting 3" },
                    { new Guid("a81c2257-d43c-4fe5-932c-4872568146d2"), "Just Chatting 5" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chatrooms_SourceChatroomId",
                table: "Messages",
                column: "SourceChatroomId",
                principalTable: "Chatrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chatrooms_SourceChatroomId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("29eb3138-07b0-4565-a3db-e9d4c113cbcc"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("730ff058-1b92-4130-b6c3-60dd7f1408f5"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("7ec0f18e-63da-4509-b4d8-447c5fcebc75"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("8446e302-50fe-4547-bdb3-d084deaddc1a"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("a81c2257-d43c-4fe5-932c-4872568146d2"));

            migrationBuilder.RenameColumn(
                name: "SourceChatroomId",
                table: "Messages",
                newName: "SourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SourceChatroomId",
                table: "Messages",
                newName: "IX_Messages_SourceId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chatrooms_SourceId",
                table: "Messages",
                column: "SourceId",
                principalTable: "Chatrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
