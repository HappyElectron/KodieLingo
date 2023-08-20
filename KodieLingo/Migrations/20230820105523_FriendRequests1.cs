using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KodieLingo.Migrations
{
    /// <inheritdoc />
    public partial class FriendRequests1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserUser1",
                columns: table => new
                {
                    FriendReqIncomingId = table.Column<int>(type: "INTEGER", nullable: false),
                    FriendReqOutgoingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUser1", x => new { x.FriendReqIncomingId, x.FriendReqOutgoingId });
                    table.ForeignKey(
                        name: "FK_UserUser1_User_FriendReqIncomingId",
                        column: x => x.FriendReqIncomingId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUser1_User_FriendReqOutgoingId",
                        column: x => x.FriendReqOutgoingId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserUser1_FriendReqOutgoingId",
                table: "UserUser1",
                column: "FriendReqOutgoingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserUser1");
        }
    }
}
