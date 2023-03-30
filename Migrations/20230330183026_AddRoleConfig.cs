using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlanningPoker.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "55cb713e-bd96-4d99-9e4b-a565adce64f9", null, "User", "USER" },
                    { "bcfca815-fdfe-4d8e-9b77-241dbc554195", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55cb713e-bd96-4d99-9e4b-a565adce64f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcfca815-fdfe-4d8e-9b77-241dbc554195");

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Description", "InProgress", "IsEstimated", "Title" },
                values: new object[] { 1, "Test Story description from backend", false, false, "Test story from backend" });

            migrationBuilder.InsertData(
                table: "Votes",
                columns: new[] { "Id", "StoryId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 420 },
                    { 2, 1, 555 }
                });
        }
    }
}
