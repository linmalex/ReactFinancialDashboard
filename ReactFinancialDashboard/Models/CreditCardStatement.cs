using Newtonsoft.Json;
using ReactFinancialDashboard.Interfaces;
using ReactFinancialDashboard.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Models
{
    public class CreditCardStatement : IViewModel
    {
        public int ID { get; set; }

        [Column(TypeName = "date"), JsonConverter(typeof(DateConverter)), JsonProperty("DueDate")]
        public DateTime DueDate { get; set; }

        [Column(TypeName = "date"), JsonConverter(typeof(DateConverter)), JsonProperty("IssueDate")]
        public DateTime IssueDate { get; set; }

        [DataType(DataType.Currency), JsonProperty("Balance")]
        public double Balance { get; set; }

        [DataType(DataType.Currency), JsonProperty("MinPayment")]
        public double MinPayment { get; set; }

        [JsonProperty("PaidStatus")]
        public string PaidStatus { get; set; }

        public string YnabAccountID { get; set; }

        public int PersonalDataID { get; set; }

        public virtual Account YnabAccount { get; set; }

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
        public string PageTitle { get; set; }

        [NotMapped]
        public bool DataLoading { get; set; }
        #endregion

        public CreditCardStatement()
        {
            NavDisplayValue = "Payments Due";
            RoutePath = "/paymentsdue";
            Glyph = "inbox";
            PageTitle = "Credit Card Statements";
            DataLoading = false;
            ColumnDisplayTitles = new string[] {
                    "Statement Date",
                    "Payment Due Date",
                    "Statement Balance",
                    "Minimum Payment",
                    "Paid Status"
                };
            JsonTitleValues = new string[] {
                    "IssueDate",
                    "DueDate",
                    "Balance",
                    "MinPayment",
                    "PaidStatus"
                };
        }
    }
}
