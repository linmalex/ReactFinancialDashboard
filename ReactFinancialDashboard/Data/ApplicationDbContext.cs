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
        public DbSet<YnabAccount> YnabAccounts { get; set; }

        public DbSet<YnabDataObject> DataObjects { get; set; }

        public DbSet<PersonalData> PersonalDatas { get; set; }

        #endregion
    }
}
