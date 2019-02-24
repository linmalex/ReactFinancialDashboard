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
            if (!IgnoreBase)
            {
                return allProps;
            };

            if (type.Name == "CreditCardStatement")
            {
                List<string> creditCardNames = new List<string>()
                {
                    "DueDate",
                    "IssueDate",
                    "Balance",
                    "MinPayment",
                    "PaidStatus"
                };
                List<JsonProperty> list = allProps.Where(p => creditCardNames.Any(a => a == p.PropertyName)).ToList();
                return list;
            }
            if (type.Name == "YnabAccount")
            {
                List<string> accountNames = new List<string>()
                {
                    "Name",
                    "Type",
                    "Balance",
                };
                List<JsonProperty> list = allProps.Where(p => accountNames.Any(a => a == p.PropertyName)).ToList();
                return list;
            }
            else
            {
                PropertyInfo[] props = type.GetProperties(~BindingFlags.FlattenHierarchy);
                return allProps.Where(p => props.Any(a => a.Name == p.PropertyName)).ToList();
            }
        }
    }
}
