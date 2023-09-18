using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BTKAkademi.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6ba7a9ed-cbc1-434c-aa85-265cd91a4f1a", null, "Editor", "EDITOR" },
                    { "e6df5780-9a8d-44bc-adb6-7d2cad879e34", null, "User", "USER" },
                    { "f88c92f5-8052-4d4e-afec-c5be44603f8a", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ba7a9ed-cbc1-434c-aa85-265cd91a4f1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6df5780-9a8d-44bc-adb6-7d2cad879e34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f88c92f5-8052-4d4e-afec-c5be44603f8a");
        }
    }
}
