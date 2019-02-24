using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Data.Utilities
{
    public class IgnoreParentPropertiesResolver : DefaultContractResolver
    {
        readonly bool IgnoreBase = false;
        public IgnoreParentPropertiesResolver(bool ignoreBase)
        {
            IgnoreBase = ignoreBase;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var allProps = base.CreateProperties(type, memberSerialization);
            if (!IgnoreBase) return allProps;

            //Choose the properties you want to serialize/deserialize
            List<string> names = new List<string>() {
                "DueDate",
                "IssueDate",
                "Balance",
                "MinPayment",
                "PaidStatus"
            };
            List<JsonProperty> list = allProps.Where(p => names.Any(a => a == p.PropertyName)).ToList();
            return list;
        }
    }
}
