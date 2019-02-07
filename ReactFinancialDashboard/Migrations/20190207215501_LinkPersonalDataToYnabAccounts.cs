using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactFinancialDashboard.Migrations
{
    public partial class LinkPersonalDataToYnabAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonalDataID",
                table: "YnabAccounts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_YnabAccounts_PersonalDataID",
                table: "YnabAccounts",
                column: "PersonalDataID");

            migrationBuilder.AddForeignKey(
                name: "FK_YnabAccounts_PersonalDatas_PersonalDataID",
                table: "YnabAccounts",
                column: "PersonalDataID",
                principalTable: "PersonalDatas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YnabAccounts_PersonalDatas_PersonalDataID",
                table: "YnabAccounts");

            migrationBuilder.DropIndex(
                name: "IX_YnabAccounts_PersonalDataID",
                table: "YnabAccounts");

            migrationBuilder.DropColumn(
                name: "PersonalDataID",
                table: "YnabAccounts");
        }
    }
}
