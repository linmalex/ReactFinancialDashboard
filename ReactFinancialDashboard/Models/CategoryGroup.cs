using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Models
{
    public class CategoryGroup
    {
        #region Properties
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("hidden")]
        public bool Hidden { get; set; }
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
        [NotMapped]
        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }

        public DataYnab Data { get; set; }
        #endregion
    }
}
