using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobsityApi.Migrations
{
    public partial class botSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2381e26a-6bba-44ff-b174-ce8ebb53fced", 0, "e49d160c-c5be-4a39-90be-115b92f70794", null, false, false, null, null, null, null, null, false, "688d14ea-88e4-415e-8690-aebc4e7c1f33", false, "FinancialBot" });

            migrationBuilder.InsertData(
                table: "Chatrooms",
                columns: new[] { "Id", "Title", "Topic" },
                values: new object[,]
                {
                    { new Guid("4a5bd72a-e11b-4a0d-a81b-af22e2e1181c"), "Financial Chat 2", "Financial" },
                    { new Guid("56d9500f-0130-4991-9e2a-aa7a16122269"), "Financial Chat 3", "Financial" },
                    { new Guid("90c8d7cf-5bb5-4bf6-af98-fb434f9f9aba"), "Just Chatting 1", "Random" },
                    { new Guid("9ed04a6c-77bd-43d8-aa37-825c314413b3"), "Financial Chat 1", "Financial" },
                    { new Guid("b7267374-1660-4a67-b062-59a63517985e"), "Just Chatting 2", "Random" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2381e26a-6bba-44ff-b174-ce8ebb53fced");

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("4a5bd72a-e11b-4a0d-a81b-af22e2e1181c"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("56d9500f-0130-4991-9e2a-aa7a16122269"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("90c8d7cf-5bb5-4bf6-af98-fb434f9f9aba"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("9ed04a6c-77bd-43d8-aa37-825c314413b3"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("b7267374-1660-4a67-b062-59a63517985e"));

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
    }
}
