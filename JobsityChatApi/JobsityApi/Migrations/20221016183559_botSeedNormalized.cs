using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobsityApi.Migrations
{
    public partial class botSeedNormalized : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1070bfed-0f3b-44df-8e73-d2065eaaecf2", 0, "71ba9e6a-f363-4ec8-910b-ddcf35a9896e", null, false, false, null, null, "FINANCIALBOT", null, null, false, "262b2118-8f5c-4728-a097-a6ed8ca394e5", false, "FinancialBot" });

            migrationBuilder.InsertData(
                table: "Chatrooms",
                columns: new[] { "Id", "Title", "Topic" },
                values: new object[,]
                {
                    { new Guid("27723ef8-2843-46ea-b409-1c24e3060c69"), "Financial Chat 1", "Financial" },
                    { new Guid("381919bc-0825-403a-a597-97f360cb96d4"), "Just Chatting 1", "Random" },
                    { new Guid("a68903fc-8269-45ad-9f41-893e69d118d3"), "Financial Chat 2", "Financial" },
                    { new Guid("e36392fc-c45e-4469-9bc8-ad5f1e8cb488"), "Just Chatting 2", "Random" },
                    { new Guid("f420d604-96a0-4c49-bb35-c08384aafc84"), "Financial Chat 3", "Financial" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1070bfed-0f3b-44df-8e73-d2065eaaecf2");

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("27723ef8-2843-46ea-b409-1c24e3060c69"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("381919bc-0825-403a-a597-97f360cb96d4"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("a68903fc-8269-45ad-9f41-893e69d118d3"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("e36392fc-c45e-4469-9bc8-ad5f1e8cb488"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("f420d604-96a0-4c49-bb35-c08384aafc84"));

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
    }
}
