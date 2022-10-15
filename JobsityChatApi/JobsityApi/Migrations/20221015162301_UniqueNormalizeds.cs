using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobsityApi.Migrations
{
    public partial class UniqueNormalizeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("8e195eaf-bd45-4b5a-94f8-bdf4c77773f5"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("e4c839a5-9908-4cb3-9a3b-6533a77439b5"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("e54b5f88-d58b-4978-98c2-19ac2ddea202"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("eec33ca0-a798-4e28-b581-6082dcf6ee0b"));

            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("fb64e486-26d5-4ccb-ae15-78814ad2ea7b"));

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

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail",
                unique: true,
                filter: "[NormalizedEmail] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "AspNetUsers");

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

            migrationBuilder.InsertData(
                table: "Chatrooms",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("8e195eaf-bd45-4b5a-94f8-bdf4c77773f5"), "Just Chatting 2" },
                    { new Guid("e4c839a5-9908-4cb3-9a3b-6533a77439b5"), "Just Chatting 3" },
                    { new Guid("e54b5f88-d58b-4978-98c2-19ac2ddea202"), "Just Chatting 4" },
                    { new Guid("eec33ca0-a798-4e28-b581-6082dcf6ee0b"), "Just Chatting 5" },
                    { new Guid("fb64e486-26d5-4ccb-ae15-78814ad2ea7b"), "Just Chatting 1" }
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");
        }
    }
}
