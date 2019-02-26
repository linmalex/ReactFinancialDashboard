﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReactFinancialDashboard.Data;

namespace ReactFinancialDashboard.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.Account", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Balance");

                    b.Property<Guid?>("BankAccountID");

                    b.Property<double>("Cleared_balance");

                    b.Property<bool>("Closed");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<bool>("On_budget");

                    b.Property<int?>("PersonalDataID");

                    b.Property<string>("Transfer_payee_id")
                        .IsRequired();

                    b.Property<string>("Type");

                    b.Property<double>("Uncleared_balance");

                    b.HasKey("ID");

                    b.HasAlternateKey("Transfer_payee_id");

                    b.HasIndex("BankAccountID");

                    b.HasIndex("PersonalDataID");

                    b.ToTable("YnabAccounts");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.BankAccount", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("PersonalDataID");

                    b.HasKey("ID");

                    b.HasIndex("PersonalDataID");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.CreditCardStatement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Autopay");

                    b.Property<DateTime>("AutopayScheduledDate")
                        .HasColumnType("date");

                    b.Property<double>("Balance");

                    b.Property<Guid?>("BankAccountID");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("date");

                    b.Property<double>("MinPayment");

                    b.Property<string>("PaidStatus");

                    b.Property<int>("PersonalDataID");

                    b.Property<double>("RemainingStatementBalance");

                    b.Property<string>("YnabAccountID");

                    b.HasKey("ID");

                    b.HasIndex("BankAccountID");

                    b.HasIndex("PersonalDataID");

                    b.HasIndex("YnabAccountID");

                    b.ToTable("CreditCardStatements");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.OtherCreditCardInfo", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BankAccountID");

                    b.Property<double>("BudgetedSpending");

                    b.Property<double>("ExtraBudgeted");

                    b.Property<double>("LastPaymentAmount");

                    b.Property<DateTime>("LastPaymentDate")
                        .HasColumnType("date");

                    b.Property<double>("RemainingStatementBalance");

                    b.Property<double>("TotalAvailable");

                    b.Property<double>("UnbudgetedSpending");

                    b.HasKey("ID");

                    b.HasIndex("BankAccountID");

                    b.ToTable("OtherCreditCardInfos");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.PersonalData", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthToken");

                    b.Property<string>("BudgetID");

                    b.Property<int?>("DataObjectID");

                    b.HasKey("ID");

                    b.HasIndex("DataObjectID");

                    b.ToTable("PersonalDatas");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.Subtransaction", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Amount");

                    b.Property<string>("CategoryId");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Memo");

                    b.Property<string>("PayeeId");

                    b.Property<string>("TransactionId");

                    b.Property<string>("TransferAccountId");

                    b.HasKey("Id");

                    b.HasIndex("TransactionId");

                    b.ToTable("Subtransactions");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.Transaction", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountID");

                    b.Property<string>("AccountName");

                    b.Property<long>("Amount");

                    b.Property<bool>("Approved");

                    b.Property<string>("CategoryId");

                    b.Property<string>("CategoryName");

                    b.Property<string>("Cleared");

                    b.Property<string>("Date");

                    b.Property<bool>("Deleted");

                    b.Property<string>("FlagColor");

                    b.Property<string>("ImportId");

                    b.Property<string>("MatchedTransactionId");

                    b.Property<string>("Memo");

                    b.Property<string>("PayeeId");

                    b.Property<string>("PayeeName");

                    b.Property<int>("PersonalDataID");

                    b.Property<string>("TransferAccountId");

                    b.Property<string>("TransferTransactionId");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("PersonalDataID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.YnabDataObject", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRetrieved");

                    b.Property<string>("Server_knowledge");

                    b.HasKey("ID");

                    b.ToTable("DataObjects");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.Account", b =>
                {
                    b.HasOne("ReactFinancialDashboard.Models.BankAccount")
                        .WithMany("YnabAccount")
                        .HasForeignKey("BankAccountID");

                    b.HasOne("ReactFinancialDashboard.Models.PersonalData", "PersonalData")
                        .WithMany("Accounts")
                        .HasForeignKey("PersonalDataID");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.BankAccount", b =>
                {
                    b.HasOne("ReactFinancialDashboard.Models.PersonalData")
                        .WithMany("BankAccounts")
                        .HasForeignKey("PersonalDataID");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.CreditCardStatement", b =>
                {
                    b.HasOne("ReactFinancialDashboard.Models.BankAccount", "BankAccount")
                        .WithMany("CreditCardStatement")
                        .HasForeignKey("BankAccountID");

                    b.HasOne("ReactFinancialDashboard.Models.PersonalData", "PersonalData")
                        .WithMany()
                        .HasForeignKey("PersonalDataID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReactFinancialDashboard.Models.Account", "YnabAccount")
                        .WithMany()
                        .HasForeignKey("YnabAccountID");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.OtherCreditCardInfo", b =>
                {
                    b.HasOne("ReactFinancialDashboard.Models.BankAccount", "BankAccount")
                        .WithMany("OtherCreditCardInfo")
                        .HasForeignKey("BankAccountID");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.PersonalData", b =>
                {
                    b.HasOne("ReactFinancialDashboard.Models.YnabDataObject", "DataObject")
                        .WithMany()
                        .HasForeignKey("DataObjectID");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.Subtransaction", b =>
                {
                    b.HasOne("ReactFinancialDashboard.Models.Transaction")
                        .WithMany("Subtransactions")
                        .HasForeignKey("TransactionId");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.Transaction", b =>
                {
                    b.HasOne("ReactFinancialDashboard.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID");

                    b.HasOne("ReactFinancialDashboard.Models.PersonalData", "PersonalData")
                        .WithMany()
                        .HasForeignKey("PersonalDataID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
