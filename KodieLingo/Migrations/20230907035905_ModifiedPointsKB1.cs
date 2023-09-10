using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KodieLingo.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedPointsKB1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeeklyKB",
                table: "User",
                newName: "WeeklyPoints");

            migrationBuilder.RenameColumn(
                name: "LifetimeKB",
                table: "User",
                newName: "LifetimePoints");

            migrationBuilder.AddColumn<int>(
                name: "KodieBukz",
                table: "User",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "KodieBukz",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KodieBukz",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "WeeklyPoints",
                table: "User",
                newName: "WeeklyKB");

            migrationBuilder.RenameColumn(
                name: "LifetimePoints",
                table: "User",
                newName: "LifetimeKB");
        }
    }
}
