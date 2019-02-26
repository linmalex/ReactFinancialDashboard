using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactFinancialDashboard.Migrations
{
    public partial class BankAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OtherCreditCardInfos",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    RemainingStatementBalance = table.Column<double>(nullable: false),
                    LastPaymentAmount = table.Column<double>(nullable: false),
                    LastPaymentDate = table.Column<DateTime>(type: "date", nullable: false),
                    TotalAvailable = table.Column<double>(nullable: false),
                    BudgetedSpending = table.Column<double>(nullable: false),
                    ExtraBudgeted = table.Column<double>(nullable: false),
                    UnbudgetedSpending = table.Column<double>(nullable: false),
                    YnabAccountID = table.Column<string>(nullable: true),
                    CreditCardStatementID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherCreditCardInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OtherCreditCardInfos_CreditCardStatements_CreditCardStatementID",
                        column: x => x.CreditCardStatementID,
                        principalTable: "CreditCardStatements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OtherCreditCardInfos_YnabAccounts_YnabAccountID",
                        column: x => x.YnabAccountID,
                        principalTable: "YnabAccounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    YnabAccountID = table.Column<string>(nullable: true),
                    CreditCardStatementID = table.Column<int>(nullable: true),
                    OtherCreditCardInfoID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BankAccounts_CreditCardStatements_CreditCardStatementID",
                        column: x => x.CreditCardStatementID,
                        principalTable: "CreditCardStatements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankAccounts_OtherCreditCardInfos_OtherCreditCardInfoID",
                        column: x => x.OtherCreditCardInfoID,
                        principalTable: "OtherCreditCardInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankAccounts_YnabAccounts_YnabAccountID",
                        column: x => x.YnabAccountID,
                        principalTable: "YnabAccounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_OtherCreditCardInfos_CreditCardStatementID",
                table: "OtherCreditCardInfos",
                column: "CreditCardStatementID");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCreditCardInfos_YnabAccountID",
                table: "OtherCreditCardInfos",
                column: "YnabAccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "OtherCreditCardInfos");
        }
    }
}
