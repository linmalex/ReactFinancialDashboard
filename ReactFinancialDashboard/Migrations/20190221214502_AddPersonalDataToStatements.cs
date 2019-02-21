using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactFinancialDashboard.Migrations
{
    public partial class AddPersonalDataToStatements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonalDataID",
                table: "CreditCardStatements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardStatements_PersonalDataID",
                table: "CreditCardStatements",
                column: "PersonalDataID");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCardStatements_PersonalDatas_PersonalDataID",
                table: "CreditCardStatements",
                column: "PersonalDataID",
                principalTable: "PersonalDatas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCardStatements_PersonalDatas_PersonalDataID",
                table: "CreditCardStatements");

            migrationBuilder.DropIndex(
                name: "IX_CreditCardStatements_PersonalDataID",
                table: "CreditCardStatements");

            migrationBuilder.DropColumn(
                name: "PersonalDataID",
                table: "CreditCardStatements");
        }
    }
}
