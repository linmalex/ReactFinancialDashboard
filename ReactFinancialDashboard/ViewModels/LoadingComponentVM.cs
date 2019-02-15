using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.ViewModels
{
    public class LoadingComponentVM
    {
        public string NavDisplayValue { get; set; }
        public string RoutePath { get; set; }
        public string Glyph { get; set; }
        public string[] LoadingData { get; set; }
        public string[] TableData { get; set; }

        List<ILoadingComponentVM> LoadingComponents { get; set; }
    }
}
