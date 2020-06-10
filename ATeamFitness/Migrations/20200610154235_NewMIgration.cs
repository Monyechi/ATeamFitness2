using Microsoft.EntityFrameworkCore.Migrations;

namespace ATeamFitness.Migrations
{
    public partial class NewMIgration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7c6277c-985f-4d77-ab45-0d29073a1726");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff11380b-95b4-4286-be0a-c7be733cad14");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Customers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.CreateTable(
                name: "TimeBlock",
                columns: table => new
                {
                    TimeBlockId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    PersonalTrainerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeBlock", x => x.TimeBlockId);
                    table.ForeignKey(
                        name: "FK_TimeBlock_PersonalTrainers_PersonalTrainerId",
                        column: x => x.PersonalTrainerId,
                        principalTable: "PersonalTrainers",
                        principalColumn: "PersonalTrainerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b5f4a598-a6f9-4063-8a80-6efc671e93f6", "bb8a6bee-5030-4675-a5a8-0b13ccb46d68", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cf0dd966-e1c9-4231-8a07-ffcebc147123", "b84ec3f5-7a82-422d-a357-c58c08b2e096", "Trainer", "TRAINER" });

            migrationBuilder.CreateIndex(
                name: "IX_TimeBlock_PersonalTrainerId",
                table: "TimeBlock",
                column: "PersonalTrainerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeBlock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5f4a598-a6f9-4063-8a80-6efc671e93f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf0dd966-e1c9-4231-8a07-ffcebc147123");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff11380b-95b4-4286-be0a-c7be733cad14", "38997978-e51f-4fef-b152-8e65598b6b38", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7c6277c-985f-4d77-ab45-0d29073a1726", "823bd172-6396-4f66-ae2b-deaff3535f77", "Trainer", "TRAINER" });
        }
    }
}
