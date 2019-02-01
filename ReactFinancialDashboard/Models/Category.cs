using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Models
{
    public class Category
    {
        #region Properties
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("category_group_id")]
        public string CategoryGroupId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("hidden")]
        public bool Hidden { get; set; }
        [JsonProperty("original_category_group_id")]
        public string OriginalCategoryGroupId { get; set; }
        [JsonProperty("note")]
        public string Note { get; set; }
        [JsonProperty("budgeted")]
        public long Budgeted { get; set; }
        [JsonProperty("activity")]
        public long Activity { get; set; }
        [JsonProperty("balance")]
        public long Balance { get; set; }
        [JsonProperty("goal_type")]
        public string GoalType { get; set; }
        [JsonProperty("goal_creation_month")]
        public DateTimeOffset? GoalCreationMonth { get; set; }
        [JsonProperty("goal_target")]
        public long GoalTarget { get; set; }
        [JsonProperty("goal_target_month")]
        public DateTimeOffset? GoalTargetMonth { get; set; }
        [JsonProperty("goal_percentage_complete")]
        public long GoalPercentageComplete { get; set; }
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
        public CategoryGroup CategoryGroup { get; set; }
        #endregion

        public void UpdateSelf()
        {
            Balance = Balance / 1000;
            Budgeted = Budgeted / 1000;
            Activity = Activity / 1000;
            GoalTarget = GoalTarget / 1000;
        }
    }
}
