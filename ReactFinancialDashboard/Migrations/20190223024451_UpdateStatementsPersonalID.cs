using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactFinancialDashboard.Migrations
{
    public partial class UpdateStatementsPersonalID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCardStatements_PersonalDatas_PersonalDataID",
                table: "CreditCardStatements");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalDataID",
                table: "CreditCardStatements",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCardStatements_PersonalDatas_PersonalDataID",
                table: "CreditCardStatements",
                column: "PersonalDataID",
                principalTable: "PersonalDatas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCardStatements_PersonalDatas_PersonalDataID",
                table: "CreditCardStatements");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalDataID",
                table: "CreditCardStatements",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCardStatements_PersonalDatas_PersonalDataID",
                table: "CreditCardStatements",
                column: "PersonalDataID",
                principalTable: "PersonalDatas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
