using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Models
{
    public class Transaction
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("memo")]
        public string Memo { get; set; }

        [JsonProperty("cleared")]
        public string Cleared { get; set; }

        [JsonProperty("approved")]
        public bool Approved { get; set; }

        [JsonProperty("flag_color")]
        public string FlagColor { get; set; }

        [JsonProperty("account_id")]
        public string AccountID { get; set; }

        [JsonProperty("payee_id")]
        public string PayeeId { get; set; }

        [JsonProperty("category_id")]
        public string CategoryId { get; set; }

        [JsonProperty("transfer_account_id")]
        public string TransferAccountId { get; set; }

        [JsonProperty("transfer_transaction_id")]
        public string TransferTransactionId { get; set; }

        [JsonProperty("matched_transaction_id")]
        public string MatchedTransactionId { get; set; }

        [JsonProperty("import_id")]
        public string ImportId { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        [JsonProperty("payee_name")]
        public string PayeeName { get; set; }

        [JsonProperty("category_name")]
        public string CategoryName { get; set; }

        [JsonProperty("subtransactions")]
        public Subtransaction[] Subtransactions { get; set; }


        public int PersonalDataID { get; set; }

        public virtual Account Account { get; set; }

        public virtual PersonalData PersonalData { get; set; }
    }
}
