using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactFinancialDashboard.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //    migrationBuilder.CreateTable(
            //        name: "AspNetRoles",
            //        columns: table => new
            //        {
            //            Id = table.Column<string>(nullable: false),
            //            Name = table.Column<string>(maxLength: 256, nullable: true),
            //            NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
            //            ConcurrencyStamp = table.Column<string>(nullable: true)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "AspNetUsers",
            //        columns: table => new
            //        {
            //            Id = table.Column<string>(nullable: false),
            //            UserName = table.Column<string>(maxLength: 256, nullable: true),
            //            NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
            //            Email = table.Column<string>(maxLength: 256, nullable: true),
            //            NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
            //            EmailConfirmed = table.Column<bool>(nullable: false),
            //            PasswordHash = table.Column<string>(nullable: true),
            //            SecurityStamp = table.Column<string>(nullable: true),
            //            ConcurrencyStamp = table.Column<string>(nullable: true),
            //            PhoneNumber = table.Column<string>(nullable: true),
            //            PhoneNumberConfirmed = table.Column<bool>(nullable: false),
            //            TwoFactorEnabled = table.Column<bool>(nullable: false),
            //            LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
            //            LockoutEnabled = table.Column<bool>(nullable: false),
            //            AccessFailedCount = table.Column<int>(nullable: false)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "DataObjects",
            //        columns: table => new
            //        {
            //            ID = table.Column<int>(nullable: false)
            //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //            Server_knowledge = table.Column<string>(nullable: true),
            //            DateRetrieved = table.Column<DateTime>(nullable: false)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_DataObjects", x => x.ID);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "PersonalDatas",
            //        columns: table => new
            //        {
            //            ID = table.Column<int>(nullable: false)
            //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //            BudgetID = table.Column<string>(nullable: true),
            //            AuthToken = table.Column<string>(nullable: true)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_PersonalDatas", x => x.ID);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "YnabAccounts",
            //        columns: table => new
            //        {
            //            ID = table.Column<string>(nullable: false),
            //            Name = table.Column<string>(nullable: true),
            //            Type = table.Column<string>(nullable: true),
            //            Balance = table.Column<double>(nullable: false),
            //            Cleared_balance = table.Column<double>(nullable: false),
            //            Note = table.Column<string>(nullable: true),
            //            Uncleared_balance = table.Column<double>(nullable: false),
            //            Transfer_payee_id = table.Column<string>(nullable: false),
            //            Deleted = table.Column<bool>(nullable: false),
            //            On_budget = table.Column<bool>(nullable: false),
            //            Closed = table.Column<bool>(nullable: false)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_YnabAccounts", x => x.ID);
            //            table.UniqueConstraint("AK_YnabAccounts_Transfer_payee_id", x => x.Transfer_payee_id);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "AspNetRoleClaims",
            //        columns: table => new
            //        {
            //            Id = table.Column<int>(nullable: false)
            //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //            RoleId = table.Column<string>(nullable: false),
            //            ClaimType = table.Column<string>(nullable: true),
            //            ClaimValue = table.Column<string>(nullable: true)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //            table.ForeignKey(
            //                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //                column: x => x.RoleId,
            //                principalTable: "AspNetRoles",
            //                principalColumn: "Id",
            //                onDelete: ReferentialAction.Cascade);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "AspNetUserClaims",
            //        columns: table => new
            //        {
            //            Id = table.Column<int>(nullable: false)
            //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //            UserId = table.Column<string>(nullable: false),
            //            ClaimType = table.Column<string>(nullable: true),
            //            ClaimValue = table.Column<string>(nullable: true)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //            table.ForeignKey(
            //                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //                column: x => x.UserId,
            //                principalTable: "AspNetUsers",
            //                principalColumn: "Id",
            //                onDelete: ReferentialAction.Cascade);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "AspNetUserLogins",
            //        columns: table => new
            //        {
            //            LoginProvider = table.Column<string>(nullable: false),
            //            ProviderKey = table.Column<string>(nullable: false),
            //            ProviderDisplayName = table.Column<string>(nullable: true),
            //            UserId = table.Column<string>(nullable: false)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //            table.ForeignKey(
            //                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //                column: x => x.UserId,
            //                principalTable: "AspNetUsers",
            //                principalColumn: "Id",
            //                onDelete: ReferentialAction.Cascade);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "AspNetUserRoles",
            //        columns: table => new
            //        {
            //            UserId = table.Column<string>(nullable: false),
            //            RoleId = table.Column<string>(nullable: false)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //            table.ForeignKey(
            //                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //                column: x => x.RoleId,
            //                principalTable: "AspNetRoles",
            //                principalColumn: "Id",
            //                onDelete: ReferentialAction.Cascade);
            //            table.ForeignKey(
            //                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //                column: x => x.UserId,
            //                principalTable: "AspNetUsers",
            //                principalColumn: "Id",
            //                onDelete: ReferentialAction.Cascade);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "AspNetUserTokens",
            //        columns: table => new
            //        {
            //            UserId = table.Column<string>(nullable: false),
            //            LoginProvider = table.Column<string>(nullable: false),
            //            Name = table.Column<string>(nullable: false),
            //            Value = table.Column<string>(nullable: true)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //            table.ForeignKey(
            //                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //                column: x => x.UserId,
            //                principalTable: "AspNetUsers",
            //                principalColumn: "Id",
            //                onDelete: ReferentialAction.Cascade);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "CreditCardStatements",
            //        columns: table => new
            //        {
            //            ID = table.Column<int>(nullable: false)
            //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //            DueDate = table.Column<DateTime>(type: "date", nullable: false),
            //            IssueDate = table.Column<DateTime>(type: "date", nullable: false),
            //            Balance = table.Column<double>(nullable: false),
            //            MinPayment = table.Column<double>(nullable: false),
            //            YnabAccountID = table.Column<string>(nullable: true)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_CreditCardStatements", x => x.ID);
            //            table.ForeignKey(
            //                name: "FK_CreditCardStatements_YnabAccounts_YnabAccountID",
            //                column: x => x.YnabAccountID,
            //                principalTable: "YnabAccounts",
            //                principalColumn: "ID",
            //                onDelete: ReferentialAction.Restrict);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "CreditCards",
            //        columns: table => new
            //        {
            //            ID = table.Column<int>(nullable: false)
            //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //            YnabAccountID = table.Column<string>(nullable: true),
            //            StatementID = table.Column<int>(nullable: true)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_CreditCards", x => x.ID);
            //            table.ForeignKey(
            //                name: "FK_CreditCards_CreditCardStatements_StatementID",
            //                column: x => x.StatementID,
            //                principalTable: "CreditCardStatements",
            //                principalColumn: "ID",
            //                onDelete: ReferentialAction.Restrict);
            //            table.ForeignKey(
            //                name: "FK_CreditCards_YnabAccounts_YnabAccountID",
            //                column: x => x.YnabAccountID,
            //                principalTable: "YnabAccounts",
            //                principalColumn: "ID",
            //                onDelete: ReferentialAction.Restrict);
            //        });

            //    migrationBuilder.CreateIndex(
            //        name: "IX_AspNetRoleClaims_RoleId",
            //        table: "AspNetRoleClaims",
            //        column: "RoleId");

            //    migrationBuilder.CreateIndex(
            //        name: "RoleNameIndex",
            //        table: "AspNetRoles",
            //        column: "NormalizedName",
            //        unique: true,
            //        filter: "[NormalizedName] IS NOT NULL");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_AspNetUserClaims_UserId",
            //        table: "AspNetUserClaims",
            //        column: "UserId");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_AspNetUserLogins_UserId",
            //        table: "AspNetUserLogins",
            //        column: "UserId");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_AspNetUserRoles_RoleId",
            //        table: "AspNetUserRoles",
            //        column: "RoleId");

            //    migrationBuilder.CreateIndex(
            //        name: "EmailIndex",
            //        table: "AspNetUsers",
            //        column: "NormalizedEmail");

            //    migrationBuilder.CreateIndex(
            //        name: "UserNameIndex",
            //        table: "AspNetUsers",
            //        column: "NormalizedUserName",
            //        unique: true,
            //        filter: "[NormalizedUserName] IS NOT NULL");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_CreditCards_StatementID",
            //        table: "CreditCards",
            //        column: "StatementID");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_CreditCards_YnabAccountID",
            //        table: "CreditCards",
            //        column: "YnabAccountID");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_CreditCardStatements_YnabAccountID",
            //        table: "CreditCardStatements",
            //        column: "YnabAccountID");
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
            //    name: "CreditCards");

            //migrationBuilder.DropTable(
            //    name: "DataObjects");

            //migrationBuilder.DropTable(
            //    name: "PersonalDatas");

            //migrationBuilder.DropTable(
            //    name: "AspNetRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "CreditCardStatements");

            //migrationBuilder.DropTable(
            //    name: "YnabAccounts");
        }
    }
}
