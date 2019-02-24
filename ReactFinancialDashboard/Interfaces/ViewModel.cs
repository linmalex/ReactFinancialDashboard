using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Interfaces
{
    public interface IViewModel
    {
        [JsonProperty("navDisplayValue")]
        string NavDisplayValue { get; set; }

        [JsonProperty("routePath")]
        string RoutePath { get; set; }

        [JsonProperty("glyph")]
        string Glyph { get; set; }

        [JsonProperty("columnDisplayTitles")]
        string[] ColumnDisplayTitles { get; set; }

        [JsonProperty("jsonTitleValues")]
        string[] JsonTitleValues { get; set; }

        [JsonProperty("data")]
        string[] Data { get; set; }

        [JsonProperty("pageTitle")]
        string PageTitle { get; set; }

        [JsonProperty("dataLoading")]
        bool DataLoading { get; set; }
    }
}
