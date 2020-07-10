using Microsoft.EntityFrameworkCore.Migrations;

namespace ATeamFitness.Migrations
{
    public partial class newMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73b79cbe-58c4-49e2-846c-a28c3c507a4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93c7b12a-4c51-4b87-b74d-4272f2e8f3cf");

            migrationBuilder.AddColumn<int>(
                name: "ThumbsDown",
                table: "PersonalTrainers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThumbsUp",
                table: "PersonalTrainers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "52777df3-fe17-47f3-b400-39b0bcdaa170", "5b2bec87-2f6a-4235-8fcc-8c323007795b", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b50fd321-c629-41e6-a9fe-7d251340c2b2", "4b43ffae-3be3-4af8-b4f6-3c1348fe6b5f", "Trainer", "TRAINER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52777df3-fe17-47f3-b400-39b0bcdaa170");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b50fd321-c629-41e6-a9fe-7d251340c2b2");

            migrationBuilder.DropColumn(
                name: "ThumbsDown",
                table: "PersonalTrainers");

            migrationBuilder.DropColumn(
                name: "ThumbsUp",
                table: "PersonalTrainers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "73b79cbe-58c4-49e2-846c-a28c3c507a4c", "33967e83-e6ec-4be4-8340-538c561d5260", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93c7b12a-4c51-4b87-b74d-4272f2e8f3cf", "6665c9a0-bdb4-4aca-9f17-82d25b2ce461", "Trainer", "TRAINER" });
        }
    }
}
