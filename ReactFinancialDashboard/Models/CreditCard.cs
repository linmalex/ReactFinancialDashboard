﻿using ReactFinancialDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Models
{
    public class CreditCard: ILoadingComponentVM
    {
        public int ID { get; set; }

        public string BankName { get; set; }

        public Account YnabAccount { get; set; }

        public Statement Statement { get; set; }
    }
}
