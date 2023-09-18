using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BTKAkademi.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class CategoryEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0209ecde-68fb-402d-8982-c0fee1e8fe21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27c1af4e-e371-4ff2-a076-3e793a1f7550");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b45f670e-82d7-4806-a4ea-f51155a165d7");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "79fb88be-2ccf-417c-b38f-c3cf61c499d5", null, "User", "USER" },
                    { "ca2def77-c506-4139-90f5-05722e9dfecd", null, "Admin", "ADMIN" },
                    { "cbf9951a-e3a3-4593-b4fe-a38a4100f063", null, "Editor", "EDITOR" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Computer Science" },
                    { 2, "Network" },
                    { 3, "Database Management Systems" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79fb88be-2ccf-417c-b38f-c3cf61c499d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca2def77-c506-4139-90f5-05722e9dfecd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbf9951a-e3a3-4593-b4fe-a38a4100f063");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0209ecde-68fb-402d-8982-c0fee1e8fe21", null, "User", "USER" },
                    { "27c1af4e-e371-4ff2-a076-3e793a1f7550", null, "Editor", "EDITOR" },
                    { "b45f670e-82d7-4806-a4ea-f51155a165d7", null, "Admin", "ADMIN" }
                });
        }
    }
}
