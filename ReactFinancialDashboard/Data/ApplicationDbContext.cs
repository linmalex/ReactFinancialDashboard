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
        #region Context Setup
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }
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

        #region tables
        public DbSet<CreditCardStatement> CreditCardStatements { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<YnabAccount> YnabAccounts { get; set; }

        public DbSet<YnabDataObject> DataObjects { get; set; }

        public DbSet<PersonalData> PersonalDatas { get; set; }

        #endregion
    }
}
