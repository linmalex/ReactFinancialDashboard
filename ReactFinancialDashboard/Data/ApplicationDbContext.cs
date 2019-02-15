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

            modelBuilder.Entity<Account>()
                .HasAlternateKey(x => x.Transfer_payee_id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        #endregion

        #region tables
        public DbSet<Statement> CreditCardStatements { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<Account> YnabAccounts { get; set; }

        public DbSet<Models.Data> DataObjects { get; set; }

        public DbSet<PersonalData> PersonalDatas { get; set; }

        #endregion
    }
}
