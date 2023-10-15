using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KodieLingo.Migrations
{
    /// <inheritdoc />
    public partial class SectionProgress1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseProgress_Course_CourseId",
                table: "CourseProgress");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseProgress",
                newName: "SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseProgress_CourseId",
                table: "CourseProgress",
                newName: "IX_CourseProgress_SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseProgress_Section_SectionId",
                table: "CourseProgress",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseProgress_Section_SectionId",
                table: "CourseProgress");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "CourseProgress",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseProgress_SectionId",
                table: "CourseProgress",
                newName: "IX_CourseProgress_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseProgress_Course_CourseId",
                table: "CourseProgress",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
