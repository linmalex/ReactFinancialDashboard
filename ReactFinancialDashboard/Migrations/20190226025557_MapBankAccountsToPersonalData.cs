using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactFinancialDashboard.Migrations
{
    public partial class MapBankAccountsToPersonalData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DataObjectID",
                table: "PersonalDatas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonalDataID",
                table: "BankAccounts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDatas_DataObjectID",
                table: "PersonalDatas",
                column: "DataObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_PersonalDataID",
                table: "BankAccounts",
                column: "PersonalDataID");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_PersonalDatas_PersonalDataID",
                table: "BankAccounts",
                column: "PersonalDataID",
                principalTable: "PersonalDatas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDatas_DataObjects_DataObjectID",
                table: "PersonalDatas",
                column: "DataObjectID",
                principalTable: "DataObjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_PersonalDatas_PersonalDataID",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDatas_DataObjects_DataObjectID",
                table: "PersonalDatas");

            migrationBuilder.DropIndex(
                name: "IX_PersonalDatas_DataObjectID",
                table: "PersonalDatas");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_PersonalDataID",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "DataObjectID",
                table: "PersonalDatas");

            migrationBuilder.DropColumn(
                name: "PersonalDataID",
                table: "BankAccounts");
        }
    }
}
