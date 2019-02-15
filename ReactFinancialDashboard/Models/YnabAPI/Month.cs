using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Models
{
    public class Month
    {
        public string MonthName { get; set; }
        public string Note { get; set; }
        public double Income { get; set; }
        public double Budgeted { get; set; }
        public double Activity { get; set; }
        public double To_Be_Budgeted { get; set; }
        public double Age_Of_Money { get; set; }
        public bool Deleted { get; set; }

        #region Relationship mapping
        public Data Data { get; set; }
        #endregion

    }
}
