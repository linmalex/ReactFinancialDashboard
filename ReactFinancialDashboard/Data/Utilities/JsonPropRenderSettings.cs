using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Data.Utilities
{
    public class JsonPropRenderSettings : DefaultContractResolver
    {
        readonly bool IgnoreBase = false;
        public List<string> PropsToRender { get; set; }
        public JsonPropRenderSettings(bool ignoreBase, List<string> propsToRender = null)
        {
            IgnoreBase = ignoreBase;
            PropsToRender = propsToRender;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var allProps = base.CreateProperties(type, memberSerialization);
            if (!IgnoreBase)
            {
                return allProps;
            };

            List<JsonProperty> list = allProps.Where(p => PropsToRender.Any(a => a == p.PropertyName)).ToList();
            return list;
        }
    }
}
