using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ReactFinancialDashboard.Data;
using ReactFinancialDashboard.Data.Utilities;
using ReactFinancialDashboard.Interfaces;

namespace ReactFinancialDashboard.Models
{
    public class Account : IViewModel
    {
        #region Properties
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        [DataType(DataType.Currency)]
        public double Balance { get; set; }

        [DataType(DataType.Currency)]
        public double Cleared_balance { get; set; }
        public string Note { get; set; }

        [DataType(DataType.Currency)]
        public double Uncleared_balance { get; set; }
        public string Transfer_payee_id { get; set; }
        public bool Deleted { get; set; }
        public bool On_budget { get; set; }
        public bool Closed { get; set; }

        public int PersonalDataID { get; set; }
        public virtual PersonalData PersonalData { get; set; }
        #region IViewModel implementation
        [NotMapped]
        public string NavDisplayValue { get; set; }

        [NotMapped]
        public string RoutePath { get; set; }

        [NotMapped]
        public string Glyph { get; set; }

        [NotMapped]
        public string[] ColumnDisplayTitles { get; set; }

        [NotMapped]
        public string[] JsonTitleValues { get; set; }

        [NotMapped]
        public string[] Data { get; set; }

        [NotMapped]
        public string PageTitle { get; set; }

        [NotMapped]
        public bool DataLoading { get; set; }
        #endregion
        #endregion

        public Account()
        {
            NavDisplayValue = "Ynab Accounts";
            RoutePath = "/ynabaccountbalances";
            Glyph = "piggy-bank";
            PageTitle = "Ynab Account Balances";
            DataLoading = false;
            ColumnDisplayTitles = new string[] {
                "Account Name",
                "Account Balance",
                "Account Type"
            };
            JsonTitleValues = new string[] {
                "Name",
                "Balance",
                "Type"
            };
        }
    }
}