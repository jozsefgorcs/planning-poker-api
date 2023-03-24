using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlanningPoker.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeededStoriesWithVotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 1, "Test Story description from backend", "Test story from backend" });

            migrationBuilder.InsertData(
                table: "Votes",
                columns: new[] { "Id", "StoryId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 420 },
                    { 2, 1, 555 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
