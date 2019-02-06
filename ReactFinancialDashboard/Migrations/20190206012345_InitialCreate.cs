using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactFinancialDashboard.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        UserName = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
            //        Email = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(nullable: false),
            //        PasswordHash = table.Column<string>(nullable: true),
            //        SecurityStamp = table.Column<string>(nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true),
            //        PhoneNumber = table.Column<string>(nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
            //        LockoutEnabled = table.Column<bool>(nullable: false),
            //        AccessFailedCount = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DataObjects",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Server_knowledge = table.Column<string>(nullable: true),
            //        DateRetrieved = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DataObjects", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "YnabAccounts",
            //    columns: table => new
            //    {
            //        ID = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(nullable: true),
            //        Type = table.Column<string>(nullable: true),
            //        On_budget = table.Column<bool>(nullable: false),
            //        Closed = table.Column<bool>(nullable: false),
            //        Note = table.Column<string>(nullable: true),
            //        Balance = table.Column<double>(nullable: false),
            //        Cleared_balance = table.Column<double>(nullable: false),
            //        Uncleared_balance = table.Column<double>(nullable: false),
            //        Transfer_payee_id = table.Column<string>(nullable: false),
            //        Deleted = table.Column<bool>(nullable: false),
            //        APR = table.Column<double>(nullable: false),
            //        Discriminator = table.Column<string>(nullable: false),
            //        PayOffDate = table.Column<DateTime>(nullable: true),
            //        GoalDateMonthlyAmount = table.Column<double>(nullable: true),
            //        PayoffPriority = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_YnabAccounts", x => x.ID);
            //        table.UniqueConstraint("AK_YnabAccounts_Transfer_payee_id", x => x.Transfer_payee_id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        RoleId = table.Column<string>(nullable: false),
            //        ClaimType = table.Column<string>(nullable: true),
            //        ClaimValue = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        UserId = table.Column<string>(nullable: false),
            //        ClaimType = table.Column<string>(nullable: true),
            //        ClaimValue = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(nullable: false),
            //        ProviderKey = table.Column<string>(nullable: false),
            //        ProviderDisplayName = table.Column<string>(nullable: true),
            //        UserId = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        RoleId = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        LoginProvider = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(nullable: false),
            //        Value = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CategoryGroups",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        Name = table.Column<string>(nullable: true),
            //        Hidden = table.Column<bool>(nullable: false),
            //        Deleted = table.Column<bool>(nullable: false),
            //        DataID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CategoryGroups", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CategoryGroups_DataObjects_DataID",
            //            column: x => x.DataID,
            //            principalTable: "DataObjects",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Transactions",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        Date = table.Column<DateTime>(nullable: false),
            //        Amount = table.Column<double>(nullable: false),
            //        Memo = table.Column<string>(nullable: true),
            //        Cleared = table.Column<string>(nullable: true),
            //        Approved = table.Column<bool>(nullable: false),
            //        Flag_color = table.Column<string>(nullable: true),
            //        Account_id = table.Column<string>(nullable: true),
            //        Account_name = table.Column<string>(nullable: true),
            //        Payee_id = table.Column<string>(nullable: true),
            //        Payee_name = table.Column<string>(nullable: true),
            //        Category_id = table.Column<string>(nullable: true),
            //        Category_name = table.Column<string>(nullable: true),
            //        Transfer_account_id = table.Column<string>(nullable: true),
            //        Transfer_transaction_id = table.Column<string>(nullable: true),
            //        Import_id = table.Column<string>(nullable: true),
            //        Deleted = table.Column<bool>(nullable: false),
            //        DataID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Transactions", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Transactions_DataObjects_DataID",
            //            column: x => x.DataID,
            //            principalTable: "DataObjects",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Categories",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        CategoryGroupId = table.Column<string>(nullable: true),
            //        Name = table.Column<string>(nullable: true),
            //        Hidden = table.Column<bool>(nullable: false),
            //        OriginalCategoryGroupId = table.Column<string>(nullable: true),
            //        Note = table.Column<string>(nullable: true),
            //        Budgeted = table.Column<long>(nullable: false),
            //        Activity = table.Column<long>(nullable: false),
            //        Balance = table.Column<long>(nullable: false),
            //        GoalType = table.Column<string>(nullable: true),
            //        GoalCreationMonth = table.Column<DateTimeOffset>(nullable: true),
            //        GoalTarget = table.Column<long>(nullable: false),
            //        GoalTargetMonth = table.Column<DateTimeOffset>(nullable: true),
            //        GoalPercentageComplete = table.Column<long>(nullable: false),
            //        Deleted = table.Column<bool>(nullable: false),
            //        CategoryGroupId1 = table.Column<Guid>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Categories", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Categories_CategoryGroups_CategoryGroupId1",
            //            column: x => x.CategoryGroupId1,
            //            principalTable: "CategoryGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Categories_CategoryGroupId1",
            //    table: "Categories",
            //    column: "CategoryGroupId1");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryGroups_DataID",
            //    table: "CategoryGroups",
            //    column: "DataID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Transactions_DataID",
            //    table: "Transactions",
            //    column: "DataID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AspNetRoleClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserLogins");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "Categories");

            //migrationBuilder.DropTable(
            //    name: "Transactions");

            //migrationBuilder.DropTable(
            //    name: "YnabAccounts");

            //migrationBuilder.DropTable(
            //    name: "AspNetRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "CategoryGroups");

            //migrationBuilder.DropTable(
            //    name: "DataObjects");
        }
    }
}
