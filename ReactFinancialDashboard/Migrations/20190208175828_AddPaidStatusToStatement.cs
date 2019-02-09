using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactFinancialDashboard.Migrations
{
    public partial class AddPaidStatusToStatement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaidStatus",
                table: "CreditCardStatements",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidStatus",
                table: "CreditCardStatements");
        }
    }
}
