using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningPoker.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddInprogressAndISEstimatedProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InProgress",
                table: "Stories",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEstimated",
                table: "Stories",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Stories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InProgress", "IsEstimated" },
                values: new object[] { false, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InProgress",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "IsEstimated",
                table: "Stories");
        }
    }
}
