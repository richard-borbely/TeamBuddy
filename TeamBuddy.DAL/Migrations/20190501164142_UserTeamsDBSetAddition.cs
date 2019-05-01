using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamBuddy.DAL.Migrations
{
    public partial class UserTeamsDBSetAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTeam_Teams_TeamId",
                table: "UserTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTeam_Users_UserId",
                table: "UserTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTeam",
                table: "UserTeam");

            migrationBuilder.RenameTable(
                name: "UserTeam",
                newName: "UserTeams");

            migrationBuilder.RenameIndex(
                name: "IX_UserTeam_TeamId",
                table: "UserTeams",
                newName: "IX_UserTeams_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTeams",
                table: "UserTeams",
                columns: new[] { "UserId", "TeamId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserTeams_Teams_TeamId",
                table: "UserTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTeams_Users_UserId",
                table: "UserTeams",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTeams_Teams_TeamId",
                table: "UserTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTeams_Users_UserId",
                table: "UserTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTeams",
                table: "UserTeams");

            migrationBuilder.RenameTable(
                name: "UserTeams",
                newName: "UserTeam");

            migrationBuilder.RenameIndex(
                name: "IX_UserTeams_TeamId",
                table: "UserTeam",
                newName: "IX_UserTeam_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTeam",
                table: "UserTeam",
                columns: new[] { "UserId", "TeamId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserTeam_Teams_TeamId",
                table: "UserTeam",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTeam_Users_UserId",
                table: "UserTeam",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
