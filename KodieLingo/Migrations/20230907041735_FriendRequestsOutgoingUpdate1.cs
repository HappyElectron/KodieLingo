using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KodieLingo.Migrations
{
    /// <inheritdoc />
    public partial class FriendRequestsOutgoingUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUser1_User_FriendReqOutgoingId",
                table: "UserUser1");

            migrationBuilder.RenameColumn(
                name: "FriendReqOutgoingId",
                table: "UserUser1",
                newName: "FriendReqIncomingParentsId");

            migrationBuilder.RenameIndex(
                name: "IX_UserUser1_FriendReqOutgoingId",
                table: "UserUser1",
                newName: "IX_UserUser1_FriendReqIncomingParentsId");

            migrationBuilder.CreateTable(
                name: "UserUser2",
                columns: table => new
                {
                    FriendReqOutgoingId = table.Column<int>(type: "INTEGER", nullable: false),
                    FriendReqOutgoingParentsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUser2", x => new { x.FriendReqOutgoingId, x.FriendReqOutgoingParentsId });
                    table.ForeignKey(
                        name: "FK_UserUser2_User_FriendReqOutgoingId",
                        column: x => x.FriendReqOutgoingId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUser2_User_FriendReqOutgoingParentsId",
                        column: x => x.FriendReqOutgoingParentsId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserUser2_FriendReqOutgoingParentsId",
                table: "UserUser2",
                column: "FriendReqOutgoingParentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUser1_User_FriendReqIncomingParentsId",
                table: "UserUser1",
                column: "FriendReqIncomingParentsId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUser1_User_FriendReqIncomingParentsId",
                table: "UserUser1");

            migrationBuilder.DropTable(
                name: "UserUser2");

            migrationBuilder.RenameColumn(
                name: "FriendReqIncomingParentsId",
                table: "UserUser1",
                newName: "FriendReqOutgoingId");

            migrationBuilder.RenameIndex(
                name: "IX_UserUser1_FriendReqIncomingParentsId",
                table: "UserUser1",
                newName: "IX_UserUser1_FriendReqOutgoingId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUser1_User_FriendReqOutgoingId",
                table: "UserUser1",
                column: "FriendReqOutgoingId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
