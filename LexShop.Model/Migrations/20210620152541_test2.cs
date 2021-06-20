using Microsoft.EntityFrameworkCore.Migrations;

namespace LexShop.Model.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAuth_Users_UserId",
                table: "UserAuth");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAuth",
                table: "UserAuth");

            migrationBuilder.RenameTable(
                name: "UserAuth",
                newName: "Auths");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_UserAuth_Email",
                table: "Auths",
                newName: "IX_Auths_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auths",
                table: "Auths",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auths_Users_UserId",
                table: "Auths",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auths_Users_UserId",
                table: "Auths");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auths",
                table: "Auths");

            migrationBuilder.RenameTable(
                name: "Auths",
                newName: "UserAuth");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameIndex(
                name: "IX_Auths_Email",
                table: "UserAuth",
                newName: "IX_UserAuth_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAuth",
                table: "UserAuth",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAuth_Users_UserId",
                table: "UserAuth",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
