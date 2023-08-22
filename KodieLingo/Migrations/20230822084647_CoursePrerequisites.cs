using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KodieLingo.Migrations
{
    /// <inheritdoc />
    public partial class CoursePrerequisites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseCourse",
                columns: table => new
                {
                    PrerequisiteId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrerequisiteParentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCourse", x => new { x.PrerequisiteId, x.PrerequisiteParentId });
                    table.ForeignKey(
                        name: "FK_CourseCourse_Course_PrerequisiteId",
                        column: x => x.PrerequisiteId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseCourse_Course_PrerequisiteParentId",
                        column: x => x.PrerequisiteParentId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseCourse_PrerequisiteParentId",
                table: "CourseCourse",
                column: "PrerequisiteParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseCourse");
        }
    }
}
