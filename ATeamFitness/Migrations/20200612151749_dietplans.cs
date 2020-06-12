using Microsoft.EntityFrameworkCore.Migrations;

namespace ATeamFitness.Migrations
{
    public partial class dietplans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "816b9b7a-3da7-496d-8151-7eb0d4001007");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e010cf21-96b2-4df8-b73a-385f87bcb57f");

            migrationBuilder.CreateTable(
                name: "DietPlans",
                columns: table => new
                {
                    PlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietType = table.Column<string>(nullable: true),
                    FitnessGoal = table.Column<string>(nullable: true),
                    FoodOptionA = table.Column<string>(nullable: true),
                    FoodOptionB = table.Column<string>(nullable: true),
                    FoodOptionC = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietPlans", x => x.PlanId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7cc54362-bf87-40f3-a98f-1164d3e6234c", "f7f6fa27-292f-4211-8b5f-9998aa9ac759", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef507c2c-f928-4a8a-823b-24d7134f2ac1", "7efdb003-0bd8-4a0a-8f49-9d1e4c61c93b", "Trainer", "TRAINER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DietPlans");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cc54362-bf87-40f3-a98f-1164d3e6234c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef507c2c-f928-4a8a-823b-24d7134f2ac1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "816b9b7a-3da7-496d-8151-7eb0d4001007", "a231b9f8-f3b2-490a-89a7-65a1d65376f1", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e010cf21-96b2-4df8-b73a-385f87bcb57f", "215f1aa8-68de-4fcd-bc52-bd0d7e821b3d", "Trainer", "TRAINER" });
        }
    }
}
