using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugSpotterBE.Migrations
{
    /// <inheritdoc />
    public partial class updatedMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agrees",
                table: "Suggestions");

            migrationBuilder.DropColumn(
                name: "Disagrees",
                table: "Suggestions");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Agrees",
                table: "Suggestions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disagrees",
                table: "Suggestions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Likes",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Likes",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Likes",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Suggestions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Agrees", "Disagrees" },
                values: new object[] { 9, 4 });

            migrationBuilder.UpdateData(
                table: "Suggestions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Agrees", "Disagrees" },
                values: new object[] { 2, 0 });
        }
    }
}
