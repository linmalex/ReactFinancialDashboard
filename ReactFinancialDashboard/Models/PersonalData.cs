using System;
using System.Collections.Generic;

namespace ReactFinancialDashboard.Models
{
    public class PersonalData
    {
        public int ID { get; set; }

        public string BudgetID { get; set; }

        public string AuthToken { get; set; }

        public List<Data> YnabDatas { get; set; }
    }
}