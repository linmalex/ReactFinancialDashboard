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

            modelBuilder.Entity("ReactFinancialDashboard.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Activity");

                    b.Property<long>("Balance");

                    b.Property<long>("Budgeted");

                    b.Property<string>("CategoryGroupId");

                    b.Property<Guid?>("CategoryGroupId1");

                    b.Property<bool>("Deleted");

                    b.Property<DateTimeOffset?>("GoalCreationMonth");

                    b.Property<long>("GoalPercentageComplete");

                    b.Property<long>("GoalTarget");

                    b.Property<DateTimeOffset?>("GoalTargetMonth");

                    b.Property<string>("GoalType");

                    b.Property<bool>("Hidden");

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<string>("OriginalCategoryGroupId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryGroupId1");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.CategoryGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DataID");

                    b.Property<bool>("Deleted");

                    b.Property<bool>("Hidden");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DataID");

                    b.ToTable("CategoryGroups");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.DataYnab", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRetrieved");

                    b.Property<string>("Server_knowledge");

                    b.HasKey("ID");

                    b.ToTable("DataObjects");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.PersonalData", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthToken");

                    b.Property<string>("BudgetID");

                    b.HasKey("ID");

                    b.ToTable("PersonalDatas");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.Transaction", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Account_id");

                    b.Property<string>("Account_name");

                    b.Property<double>("Amount");

                    b.Property<bool>("Approved");

                    b.Property<string>("Category_id");

                    b.Property<string>("Category_name");

                    b.Property<string>("Cleared");

                    b.Property<int?>("DataID");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Flag_color");

                    b.Property<string>("Import_id");

                    b.Property<string>("Memo");

                    b.Property<string>("Payee_id");

                    b.Property<string>("Payee_name");

                    b.Property<string>("Transfer_account_id");

                    b.Property<string>("Transfer_transaction_id");

                    b.HasKey("Id");

                    b.HasIndex("DataID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.YnabAccount", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("APR");

                    b.Property<double>("Balance");

                    b.Property<double>("Cleared_balance");

                    b.Property<bool>("Closed");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<bool>("On_budget");

                    b.Property<string>("Transfer_payee_id")
                        .IsRequired();

                    b.Property<string>("Type");

                    b.Property<double>("Uncleared_balance");

                    b.HasKey("ID");

                    b.HasAlternateKey("Transfer_payee_id");

                    b.ToTable("YnabAccounts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("YnabAccount");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.YnabAssetAccount", b =>
                {
                    b.HasBaseType("ReactFinancialDashboard.Models.YnabAccount");


                    b.ToTable("YnabAssetAccount");

                    b.HasDiscriminator().HasValue("YnabAssetAccount");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.YnabLiabilityAccount", b =>
                {
                    b.HasBaseType("ReactFinancialDashboard.Models.YnabAccount");

                    b.Property<double>("GoalDateMonthlyAmount");

                    b.Property<DateTime>("PayOffDate");

                    b.Property<int>("PayoffPriority");

                    b.ToTable("YnabLiabilityAccount");

                    b.HasDiscriminator().HasValue("YnabLiabilityAccount");
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

            modelBuilder.Entity("ReactFinancialDashboard.Models.Category", b =>
                {
                    b.HasOne("ReactFinancialDashboard.Models.CategoryGroup", "CategoryGroup")
                        .WithMany()
                        .HasForeignKey("CategoryGroupId1");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.CategoryGroup", b =>
                {
                    b.HasOne("ReactFinancialDashboard.Models.DataYnab", "Data")
                        .WithMany()
                        .HasForeignKey("DataID");
                });

            modelBuilder.Entity("ReactFinancialDashboard.Models.Transaction", b =>
                {
                    b.HasOne("ReactFinancialDashboard.Models.DataYnab", "Data")
                        .WithMany()
                        .HasForeignKey("DataID");
                });
#pragma warning restore 612, 618
        }
    }
}
