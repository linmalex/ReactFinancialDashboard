using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReactFinancialDashboard.Controllers;
using ReactFinancialDashboard.Data;
using ReactFinancialDashboard.Interfaces;
using ReactFinancialDashboard.Models;

namespace ReactFinancialDashboard.ViewModels
{
    public partial class DataVM
    {
        [JsonProperty("personalDataID")]
        public int PersonalDataID { get; set; }

        [JsonProperty("navbarTitle")]
        public string NavbarTitle { get; set; }

        [JsonProperty("homeRoutePath")]
        public string HomeRoutePath { get; set; }

        [JsonProperty("componentsList")]
        public List<BodyComponent> ComponentsList { get; set; }

        public DataVM(List<IViewModel> viewModels, int id)
        {
            PersonalDataID = id;
            NavbarTitle = "Lindsay's Financial Dashboard";
            HomeRoutePath = "/";
            ComponentsList = new List<BodyComponent>();
            foreach (IViewModel item in viewModels)
            {
                BodyComponent bodyComponent = new BodyComponent(item);
                ComponentsList.Add(bodyComponent);
            }
        }
    }

    public partial class BodyComponent
    {
        [JsonProperty("navDisplayValue")]
        public string NavDisplayValue { get; set; }

        [JsonProperty("routePath")]
        public string RoutePath { get; set; }

        [JsonProperty("glyph")]
        public string Glyph { get; set; }

        [JsonProperty("columnDisplayTitles")]
        public string[] ColumnDisplayTitles { get; set; }

        [JsonProperty("jsonTitleValues")]
        public string[] JsonTitleValues { get; set; }

        [JsonProperty("data")]
        public string[] Data { get; set; }

        [JsonProperty("pageTitle")]
        public string PageTitle { get; set; }

        [JsonProperty("dataLoading")]
        public bool DataLoading { get; set; }

        public BodyComponent(IViewModel viewModel)
        {
            NavDisplayValue = viewModel.NavDisplayValue;
            RoutePath = viewModel.RoutePath;
            Glyph = viewModel.Glyph;
            PageTitle = viewModel.PageTitle;
            DataLoading = viewModel.DataLoading;
            ColumnDisplayTitles = viewModel.ColumnDisplayTitles;
        }
    }
}