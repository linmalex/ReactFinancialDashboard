using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReactFinancialDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }
        #region Context Setup
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<YnabAccount>()
                .HasAlternateKey(x => x.Transfer_payee_id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        #endregion

        #region Ynab Data definitions
        public DbSet<YnabAssetAccount> AssetAccount { get; set; }

        public DbSet<YnabLiabilityAccount> LiabilityAccount { get; set; }

        public DbSet<YnabAccount> YnabAccounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<GoalStatus> Goals { get; set; }

        public DbSet<DataYnab> DataObjects { get; set; }

        public DbSet<CategoryGroup> CategoryGroups { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Statement> Statements { get; set; }
        #endregion
    }
}
