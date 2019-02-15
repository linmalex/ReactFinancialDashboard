using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Models
{
    public class Category
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public bool Hidden { get; set; }
        public string Original_category_group_ID { get; set; }
        public string Note { get; set; }
        public double Budgeted { get; set; }
        public double Activity { get; set; }
        public double Balance{ get; set; }
        public double Goal_Target { get; set; }
        public string Goal_Type { get; set; }
        public string Goal_Creation_Month { get; set; }
        public string Goal_Target_Month { get; set; }
        public double Goal_Percentage_Complete { get; set; }
        public bool Deleted { get; set; }

        #region Relationship Mapping Properties
        public Category_Group CategoryGroup{ get; set; }
        public Account Account { get; set; }
        #endregion
    }
}
