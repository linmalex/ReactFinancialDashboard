using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactFinancialDashboard.Migrations
{
    public partial class ImproveBankAccountModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_CreditCardStatements_CreditCardStatementID",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_OtherCreditCardInfos_OtherCreditCardInfoID",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_YnabAccounts_YnabAccountID",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherCreditCardInfos_CreditCardStatements_CreditCardStatementID",
                table: "OtherCreditCardInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherCreditCardInfos_YnabAccounts_YnabAccountID",
                table: "OtherCreditCardInfos");

            migrationBuilder.DropIndex(
                name: "IX_OtherCreditCardInfos_CreditCardStatementID",
                table: "OtherCreditCardInfos");

            migrationBuilder.DropIndex(
                name: "IX_OtherCreditCardInfos_YnabAccountID",
                table: "OtherCreditCardInfos");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_CreditCardStatementID",
                table: "BankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_OtherCreditCardInfoID",
                table: "BankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_YnabAccountID",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "CreditCardStatementID",
                table: "OtherCreditCardInfos");

            migrationBuilder.DropColumn(
                name: "YnabAccountID",
                table: "OtherCreditCardInfos");

            migrationBuilder.DropColumn(
                name: "CreditCardStatementID",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "OtherCreditCardInfoID",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "YnabAccountID",
                table: "BankAccounts");

            migrationBuilder.AddColumn<Guid>(
                name: "BankAccountID",
                table: "YnabAccounts",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BankAccountID",
                table: "OtherCreditCardInfos",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BankAccountID",
                table: "CreditCardStatements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_YnabAccounts_BankAccountID",
                table: "YnabAccounts",
                column: "BankAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCreditCardInfos_BankAccountID",
                table: "OtherCreditCardInfos",
                column: "BankAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardStatements_BankAccountID",
                table: "CreditCardStatements",
                column: "BankAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCardStatements_BankAccounts_BankAccountID",
                table: "CreditCardStatements",
                column: "BankAccountID",
                principalTable: "BankAccounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherCreditCardInfos_BankAccounts_BankAccountID",
                table: "OtherCreditCardInfos",
                column: "BankAccountID",
                principalTable: "BankAccounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YnabAccounts_BankAccounts_BankAccountID",
                table: "YnabAccounts",
                column: "BankAccountID",
                principalTable: "BankAccounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCardStatements_BankAccounts_BankAccountID",
                table: "CreditCardStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherCreditCardInfos_BankAccounts_BankAccountID",
                table: "OtherCreditCardInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_YnabAccounts_BankAccounts_BankAccountID",
                table: "YnabAccounts");

            migrationBuilder.DropIndex(
                name: "IX_YnabAccounts_BankAccountID",
                table: "YnabAccounts");

            migrationBuilder.DropIndex(
                name: "IX_OtherCreditCardInfos_BankAccountID",
                table: "OtherCreditCardInfos");

            migrationBuilder.DropIndex(
                name: "IX_CreditCardStatements_BankAccountID",
                table: "CreditCardStatements");

            migrationBuilder.DropColumn(
                name: "BankAccountID",
                table: "YnabAccounts");

            migrationBuilder.DropColumn(
                name: "BankAccountID",
                table: "OtherCreditCardInfos");

            migrationBuilder.DropColumn(
                name: "BankAccountID",
                table: "CreditCardStatements");

            migrationBuilder.AddColumn<int>(
                name: "CreditCardStatementID",
                table: "OtherCreditCardInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YnabAccountID",
                table: "OtherCreditCardInfos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreditCardStatementID",
                table: "BankAccounts",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OtherCreditCardInfoID",
                table: "BankAccounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YnabAccountID",
                table: "BankAccounts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OtherCreditCardInfos_CreditCardStatementID",
                table: "OtherCreditCardInfos",
                column: "CreditCardStatementID");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCreditCardInfos_YnabAccountID",
                table: "OtherCreditCardInfos",
                column: "YnabAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_CreditCardStatementID",
                table: "BankAccounts",
                column: "CreditCardStatementID");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_OtherCreditCardInfoID",
                table: "BankAccounts",
                column: "OtherCreditCardInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_YnabAccountID",
                table: "BankAccounts",
                column: "YnabAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_CreditCardStatements_CreditCardStatementID",
                table: "BankAccounts",
                column: "CreditCardStatementID",
                principalTable: "CreditCardStatements",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_OtherCreditCardInfos_OtherCreditCardInfoID",
                table: "BankAccounts",
                column: "OtherCreditCardInfoID",
                principalTable: "OtherCreditCardInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_YnabAccounts_YnabAccountID",
                table: "BankAccounts",
                column: "YnabAccountID",
                principalTable: "YnabAccounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherCreditCardInfos_CreditCardStatements_CreditCardStatementID",
                table: "OtherCreditCardInfos",
                column: "CreditCardStatementID",
                principalTable: "CreditCardStatements",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherCreditCardInfos_YnabAccounts_YnabAccountID",
                table: "OtherCreditCardInfos",
                column: "YnabAccountID",
                principalTable: "YnabAccounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
