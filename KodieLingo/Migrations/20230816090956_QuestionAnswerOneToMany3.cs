using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KodieLingo.Migrations
{
    /// <inheritdoc />
    public partial class QuestionAnswerOneToMany3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "QuestionString" },
                values: new object[] { 1, "Why" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerString", "IsValid", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Ned's fault", false, 1 },
                    { 2, "Aiden's fault", true, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
