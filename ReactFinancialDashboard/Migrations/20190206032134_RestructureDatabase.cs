using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactFinancialDashboard.Migrations
{
    public partial class RestructureDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "CategoryGroups");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "YnabAccounts");

            migrationBuilder.DropColumn(
                name: "GoalDateMonthlyAmount",
                table: "YnabAccounts");

            migrationBuilder.DropColumn(
                name: "PayOffDate",
                table: "YnabAccounts");

            migrationBuilder.DropColumn(
                name: "PayoffPriority",
                table: "YnabAccounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "YnabAccounts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "GoalDateMonthlyAmount",
                table: "YnabAccounts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PayOffDate",
                table: "YnabAccounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PayoffPriority",
                table: "YnabAccounts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataID = table.Column<int>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Hidden = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryGroups_DataObjects_DataID",
                        column: x => x.DataID,
                        principalTable: "DataObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Account_id = table.Column<string>(nullable: true),
                    Account_name = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    Category_id = table.Column<string>(nullable: true),
                    Category_name = table.Column<string>(nullable: true),
                    Cleared = table.Column<string>(nullable: true),
                    DataID = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Flag_color = table.Column<string>(nullable: true),
                    Import_id = table.Column<string>(nullable: true),
                    Memo = table.Column<string>(nullable: true),
                    Payee_id = table.Column<string>(nullable: true),
                    Payee_name = table.Column<string>(nullable: true),
                    Transfer_account_id = table.Column<string>(nullable: true),
                    Transfer_transaction_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_DataObjects_DataID",
                        column: x => x.DataID,
                        principalTable: "DataObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Activity = table.Column<long>(nullable: false),
                    Balance = table.Column<long>(nullable: false),
                    Budgeted = table.Column<long>(nullable: false),
                    CategoryGroupId = table.Column<string>(nullable: true),
                    CategoryGroupId1 = table.Column<Guid>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    GoalCreationMonth = table.Column<DateTimeOffset>(nullable: true),
                    GoalPercentageComplete = table.Column<long>(nullable: false),
                    GoalTarget = table.Column<long>(nullable: false),
                    GoalTargetMonth = table.Column<DateTimeOffset>(nullable: true),
                    GoalType = table.Column<string>(nullable: true),
                    Hidden = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    OriginalCategoryGroupId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_CategoryGroups_CategoryGroupId1",
                        column: x => x.CategoryGroupId1,
                        principalTable: "CategoryGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryGroupId1",
                table: "Categories",
                column: "CategoryGroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryGroups_DataID",
                table: "CategoryGroups",
                column: "DataID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DataID",
                table: "Transactions",
                column: "DataID");
        }
    }
}
