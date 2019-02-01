using ReactFinancialDashboard.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Models
{
    public class DataYnab
    {
        #region Properties
        public int ID { get; set; }
        public string Server_knowledge { get; set; }
        public DateTime DateRetrieved { get; set; }
        [NotMapped]
        public List<Transaction> Transactions { get; set; }
        [NotMapped]
        public List<YnabAccount> YnabAccounts { get; set; }
        [NotMapped]
        public List<CategoryGroup> CategoryGroups { get; set; }
        #endregion

        #region Constructors
        public DataYnab() { }
        ///data object to hold all new YNAB data for purposes of obtaining data at startup
        public DataYnab(ApplicationDbContext context, bool requestAllData)
        {
            //string uri = requestAllData ? SetURI_AllTransactions() : SetURI_RecentTransactions(GetLastKnowledge(context.DataObjects.ToList()));
            //JObject transactionsJSON = JsonObject(uri).Result;
            //Server_knowledge = JsonToServerKnowledge(transactionsJSON);
            //Transactions = JsonToTransactions(transactionsJSON);
            //YnabAccounts = GetAccounts();
            //DateRetrieved = DateTime.Now;
            //CategoryGroups = GetCategoryGroups();
        }
        #endregion
    }
}
