using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KodieLingo.Migrations
{
    /// <inheritdoc />
    public partial class SectionsTopics6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Topic",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Section",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Learning how computers interpret commands", "Procedural Programming" });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 1,
                column: "SectionId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Topic_SectionId",
                table: "Topic",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Section_SectionId",
                table: "Topic",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Section_SectionId",
                table: "Topic");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropIndex(
                name: "IX_Topic_SectionId",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Topic");
        }
    }
}
