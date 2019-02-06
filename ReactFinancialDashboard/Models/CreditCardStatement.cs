using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Models
{
    public class CreditCardStatement
    {
        public int ID { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime IssueDate { get; set; }

        public int Balance { get; set; }

        public int MinPayment { get; set; }
    }
}
