using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Models
{
    public class Subtransaction
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("memo")]
        public string Memo { get; set; }

        [JsonProperty("payee_id")]
        public string PayeeId { get; set; }

        [JsonProperty("category_id")]
        public string CategoryId { get; set; }

        [JsonProperty("transfer_account_id")]
        public string TransferAccountId { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }
}
