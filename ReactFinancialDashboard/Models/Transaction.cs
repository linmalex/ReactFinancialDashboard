using ReactFinancialDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Models
{
    public class Transaction: ILoadingComponentVM
    {
        public string Account_id { get; set; }
        public string Date { get; set; }
        public int Amount { get; set; }
        public string Payee_id { get; set; }
        public string Payee_name { get; set; }
        public string Category_id { get; set; }
        public string Import_id { get; set; }
        public string Memo { get; set; }
        public bool Cleared { get; set; }
        public bool Approved { get; set; }
        public string Flag_color { get; set; }

        public string YnabAccountID { get; set; }

        public virtual YnabAccount YnabAccount { get; set; }
    }
}
