﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Models
{
    public class CreditCard
    {
        public int ID { get; set; }

        public YnabAccount YnabAccount { get; set; }

        public CreditCardStatement Statement { get; set; }
    }
}