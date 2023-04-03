using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _123003042023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetUser_Meets_MeetsId",
                table: "MeetUser");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetUser_Users_SubscriberId",
                table: "MeetUser");

            migrationBuilder.RenameColumn(
                name: "SubscriberId",
                table: "MeetUser",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "MeetsId",
                table: "MeetUser",
                newName: "MeetId");

            migrationBuilder.RenameIndex(
                name: "IX_MeetUser_SubscriberId",
                table: "MeetUser",
                newName: "IX_MeetUser_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetUser_Meets_MeetId",
                table: "MeetUser",
                column: "MeetId",
                principalTable: "Meets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetUser_Users_UserId",
                table: "MeetUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetUser_Meets_MeetId",
                table: "MeetUser");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetUser_Users_UserId",
                table: "MeetUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MeetUser",
                newName: "SubscriberId");

            migrationBuilder.RenameColumn(
                name: "MeetId",
                table: "MeetUser",
                newName: "MeetsId");

            migrationBuilder.RenameIndex(
                name: "IX_MeetUser_UserId",
                table: "MeetUser",
                newName: "IX_MeetUser_SubscriberId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetUser_Meets_MeetsId",
                table: "MeetUser",
                column: "MeetsId",
                principalTable: "Meets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetUser_Users_SubscriberId",
                table: "MeetUser",
                column: "SubscriberId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
