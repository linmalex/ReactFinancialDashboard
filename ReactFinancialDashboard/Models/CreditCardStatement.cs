﻿using Newtonsoft.Json;
using ReactFinancialDashboard.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Models
{
    public class CreditCardStatement
    {
        public int ID { get; set; }

        [Column(TypeName = "date"), JsonConverter(typeof(DateConverter))]
        public DateTime DueDate { get; set; }

        [Column(TypeName = "date"), JsonConverter(typeof(DateConverter))]
        public DateTime IssueDate { get; set; }

        [DataType(DataType.Currency)]
        public double Balance { get; set; }

        [DataType(DataType.Currency)]
        public double MinPayment { get; set; }

        public YnabAccount YnabAccount { get; set; }
    }
}
