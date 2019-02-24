using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactFinancialDashboard.Migrations
{
    public partial class AddYnabTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Amount = table.Column<long>(nullable: false),
                    Memo = table.Column<string>(nullable: true),
                    Cleared = table.Column<string>(nullable: true),
                    Approved = table.Column<bool>(nullable: false),
                    FlagColor = table.Column<string>(nullable: true),
                    AccountID = table.Column<string>(nullable: true),
                    PayeeId = table.Column<string>(nullable: true),
                    CategoryId = table.Column<string>(nullable: true),
                    TransferAccountId = table.Column<string>(nullable: true),
                    TransferTransactionId = table.Column<string>(nullable: true),
                    MatchedTransactionId = table.Column<string>(nullable: true),
                    ImportId = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    AccountName = table.Column<string>(nullable: true),
                    PayeeName = table.Column<string>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true),
                    PersonalDataID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Transactions_YnabAccounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "YnabAccounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_PersonalDatas_PersonalDataID",
                        column: x => x.PersonalDataID,
                        principalTable: "PersonalDatas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subtransactions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TransactionId = table.Column<string>(nullable: true),
                    Amount = table.Column<long>(nullable: false),
                    Memo = table.Column<string>(nullable: true),
                    PayeeId = table.Column<string>(nullable: true),
                    CategoryId = table.Column<string>(nullable: true),
                    TransferAccountId = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subtransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subtransactions_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subtransactions_TransactionId",
                table: "Subtransactions",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountID",
                table: "Transactions",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PersonalDataID",
                table: "Transactions",
                column: "PersonalDataID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subtransactions");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatementID = table.Column<int>(nullable: true),
                    YnabAccountID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CreditCards_CreditCardStatements_StatementID",
                        column: x => x.StatementID,
                        principalTable: "CreditCardStatements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditCards_YnabAccounts_YnabAccountID",
                        column: x => x.YnabAccountID,
                        principalTable: "YnabAccounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_StatementID",
                table: "CreditCards",
                column: "StatementID");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_YnabAccountID",
                table: "CreditCards",
                column: "YnabAccountID");
        }
    }
}
