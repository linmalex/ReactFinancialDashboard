using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Models
{
    public class Category_Group
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public bool Hidden { get; set; }
        public bool Deleted { get; set; }

        #region Relationship mapping properties
        public ICollection<Category> Categories { get; set; }
        public Data Data { get; set; }
        #endregion
    }
}
