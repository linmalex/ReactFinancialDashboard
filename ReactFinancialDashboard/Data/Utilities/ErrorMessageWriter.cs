using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;

namespace ReactFinancialDashboard.Data.Utilities
{
    public class ErrorMessageWriter
    {
        public static JObject ExceptionToJObjectWriter(Exception e)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("errorMessage");
                writer.WriteValue(e.Message);
                writer.WriteEndObject();
            }
            return JObject.Parse(sw.ToString());
        }
    }
}
