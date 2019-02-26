using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Models
{
    public class BankAccount
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public List<Account> YnabAccount { get; set; }

        public List<CreditCardStatement> CreditCardStatement { get; set; }

        public List<OtherCreditCardInfo> OtherCreditCardInfo { get; set; }

    }
}
