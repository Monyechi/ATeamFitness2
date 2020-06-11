using Microsoft.EntityFrameworkCore.Migrations;

namespace ATeamFitness.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd570bde-ffe6-48f6-9efa-bf010c15c813");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0656e74-ecff-4821-9517-750144b8c0f9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7ee6d84-08f3-492f-85d3-fd9e732b37d8", "3d553cd1-2718-43ba-9b39-907db7182a0f", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87e4dd44-4bd0-4383-a366-768d77847f77", "2c4e99a9-c315-4724-b39e-e871040e16c5", "Trainer", "TRAINER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87e4dd44-4bd0-4383-a366-768d77847f77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7ee6d84-08f3-492f-85d3-fd9e732b37d8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd570bde-ffe6-48f6-9efa-bf010c15c813", "13cedac6-e388-47e7-af96-4055a2af86f5", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0656e74-ecff-4821-9517-750144b8c0f9", "c61a7941-c174-4b68-bd1e-27b221305dea", "Trainer", "TRAINER" });
        }
    }
}
