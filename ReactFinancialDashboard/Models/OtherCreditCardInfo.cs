using Newtonsoft.Json;
using ReactFinancialDashboard.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Models
{
    public class OtherCreditCardInfo
    {
        public Guid ID { get; set; }

        [DataType(DataType.Currency), JsonProperty("RemainingStatementBalance")]
        public double RemainingStatementBalance { get; set; }

        [DataType(DataType.Currency), JsonProperty("LastPayAmount")]
        public double LastPaymentAmount { get; set; }

        [Column(TypeName = "date"), JsonConverter(typeof(DateConverter)), JsonProperty("LastPaymentDate")]
        public DateTime LastPaymentDate { get; set; }

        [DataType(DataType.Currency), JsonProperty("TotalAvailable")]
        public double TotalAvailable { get; set; }

        [DataType(DataType.Currency), JsonProperty("BudgetedSpending")]
        public double BudgetedSpending { get; set; }

        [DataType(DataType.Currency), JsonProperty("ExtraBudgeted")]
        public double ExtraBudgeted { get; set; }

        [DataType(DataType.Currency), JsonProperty("UnbudgetedSpending")]
        public double UnbudgetedSpending { get; set; }

        public BankAccount BankAccount { get; set; }
    }
}
