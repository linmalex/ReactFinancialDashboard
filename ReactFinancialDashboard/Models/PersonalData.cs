using System;
using System.Collections.Generic;

namespace ReactFinancialDashboard.Models
{
    public class PersonalData
    {
        public Dictionary<string, double> InterestRatesDictionary { get; set; }
        public Dictionary<string, string> AccountsIdDictionary { get; set; }
        public Dictionary<string, PayoffPriority> PIFGoalStatus { get; set; }
        public DateTime PayOffDate { get; set; }
        public string BudgetID { get; set; }
        public string AuthToken { get; set; }
        public double MonthlyIncomeSource1 { get; set; }
        public double MonthlyIncomeSource2 { get; set; }


    }
}