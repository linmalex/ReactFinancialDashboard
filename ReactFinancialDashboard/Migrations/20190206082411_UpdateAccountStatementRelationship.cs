using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactFinancialDashboard.Migrations
{
    public partial class UpdateAccountStatementRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountID",
                table: "CreditCardStatements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardStatements_AccountID",
                table: "CreditCardStatements",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCardStatements_YnabAccounts_AccountID",
                table: "CreditCardStatements",
                column: "AccountID",
                principalTable: "YnabAccounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCardStatements_YnabAccounts_AccountID",
                table: "CreditCardStatements");

            migrationBuilder.DropIndex(
                name: "IX_CreditCardStatements_AccountID",
                table: "CreditCardStatements");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "CreditCardStatements");
        }
    }
}
