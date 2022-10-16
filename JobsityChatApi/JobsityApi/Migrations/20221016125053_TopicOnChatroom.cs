using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobsityApi.Migrations
{
    public partial class TopicOnChatroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("1402f602-d59c-4f2d-8fae-588d89518430"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("5466234f-f627-478f-a42e-d95f26b3a762"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("72e25764-a0ca-430d-b6b0-93e3875c0303"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("b5ce55bc-db23-4ab8-9053-66db58a2cb31"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("f5de2fe9-098f-4c6b-a0ce-7d461de6536a"));

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Chatrooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Chatrooms",
                columns: new[] { "Id", "Title", "Topic" },
                values: new object[,]
                {
                    { new Guid("5072a45d-804d-4b2d-9495-6296fd480317"), "Financial Chat 3", "Financial" },
                    { new Guid("8aa601d2-23ae-4ac3-a7fc-ce07f0d54b2f"), "Financial Chat 2", "Financial" },
                    { new Guid("96908687-36b6-47f4-b2d8-eb618a8a94c9"), "Financial Chat 1", "Financial" },
                    { new Guid("b439ba32-fead-40ff-a58b-ac0c3cc5932f"), "Just Chatting 2", "Random" },
                    { new Guid("c2bad795-dc61-4842-be25-9e944f206259"), "Just Chatting 1", "Random" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("5072a45d-804d-4b2d-9495-6296fd480317"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("8aa601d2-23ae-4ac3-a7fc-ce07f0d54b2f"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("96908687-36b6-47f4-b2d8-eb618a8a94c9"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("b439ba32-fead-40ff-a58b-ac0c3cc5932f"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("c2bad795-dc61-4842-be25-9e944f206259"));

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Chatrooms");

            migrationBuilder.InsertData(
                table: "Chatrooms",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("1402f602-d59c-4f2d-8fae-588d89518430"), "Just Chatting 4" },
                    { new Guid("5466234f-f627-478f-a42e-d95f26b3a762"), "Just Chatting 1" },
                    { new Guid("72e25764-a0ca-430d-b6b0-93e3875c0303"), "Just Chatting 2" },
                    { new Guid("b5ce55bc-db23-4ab8-9053-66db58a2cb31"), "Just Chatting 3" },
                    { new Guid("f5de2fe9-098f-4c6b-a0ce-7d461de6536a"), "Just Chatting 5" }
                });
        }
    }
}
