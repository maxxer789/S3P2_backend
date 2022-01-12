using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountService.Migrations
{
    public partial class groupRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountGroup_Accounts_AccountId",
                table: "AccountGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountGroup",
                table: "AccountGroup");

            migrationBuilder.RenameTable(
                name: "AccountGroup",
                newName: "AccountGroups");

            migrationBuilder.RenameIndex(
                name: "IX_AccountGroup_AccountId",
                table: "AccountGroups",
                newName: "IX_AccountGroups_AccountId");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AccountGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountGroups",
                table: "AccountGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountGroups_Accounts_AccountId",
                table: "AccountGroups",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountGroups_Accounts_AccountId",
                table: "AccountGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountGroups",
                table: "AccountGroups");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AccountGroups");

            migrationBuilder.RenameTable(
                name: "AccountGroups",
                newName: "AccountGroup");

            migrationBuilder.RenameIndex(
                name: "IX_AccountGroups_AccountId",
                table: "AccountGroup",
                newName: "IX_AccountGroup_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountGroup",
                table: "AccountGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountGroup_Accounts_AccountId",
                table: "AccountGroup",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
