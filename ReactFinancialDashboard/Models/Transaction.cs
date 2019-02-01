using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Models
{
    public class Transaction
    {
        public string Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Currency)]
        public double Amount { get; set; }
        public string Memo { get; set; }
        public string Cleared { get; set; }
        public bool Approved { get; set; }
        public string Flag_color { get; set; }
        public string Account_id { get; set; }
        [Display(Name = "Account Name")]
        public string Account_name { get; set; }
        public string Payee_id { get; set; }
        [Display(Name = "Payee")]
        public string Payee_name { get; set; }
        public string Category_id { get; set; }
        [Display(Name = "Category")]
        public string Category_name { get; set; }
        public string Transfer_account_id { get; set; }
        public string Transfer_transaction_id { get; set; }
        public string Import_id { get; set; }
        public bool Deleted { get; set; }

        public DataYnab Data { get; set; }

    }
    public class TransactionSet
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public double Sum { get; set; }
    }
}
