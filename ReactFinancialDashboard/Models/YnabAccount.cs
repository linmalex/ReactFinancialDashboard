using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ReactFinancialDashboard.Data;

namespace ReactFinancialDashboard.Models {
    public class YnabAccount {
        #region Properties
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool On_budget { get; set; }
        public bool Closed { get; set; }
        public string Note { get; set; }

        [DataType (DataType.Currency)]
        public double Balance { get; set; }

        [DataType (DataType.Currency)]
        public double Cleared_balance { get; set; }

        [DataType (DataType.Currency)]
        public double Uncleared_balance { get; set; }
        public string Transfer_payee_id { get; set; }
        public bool Deleted { get; set; }

        [DisplayFormat (DataFormatString = "{0:P2}")] //.04 => 4% 
        public double APR { get; set; }
        //todo: add code to update this when adding a new statement
        #endregion

    }
}