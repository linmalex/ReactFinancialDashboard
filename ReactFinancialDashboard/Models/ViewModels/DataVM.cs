using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReactFinancialDashboard.Controllers;
using ReactFinancialDashboard.Data;
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
        public List<LoadingComponent> ComponentsList { get; set; }

        //public DataVM (int id) {
        //    PersonalDataID = id;
        //    NavbarTitle = "Lindsay's Financial Dashboard";
        //    HomeRoutePath = "/";
        //    ComponentsList = new List<LoadingComponent> () {
        //        new LoadingComponent ("paymentsDue"),
        //        new LoadingComponent ("ynabAccounts"),
        //        new LoadingComponent ("creditCards")
        //    };
        //}

        public DataVM(PersonalData personalData)
        {
            PersonalDataID = personalData.ID;
            NavbarTitle = "Lindsay's Financial Dashboard";
            HomeRoutePath = "/";
            ComponentsList = new List<LoadingComponent>() {
                new LoadingComponent ("paymentsDue"),
                new LoadingComponent ("ynabAccounts"),
                new LoadingComponent ("creditCards")
            };
        }
    }

    public partial class LoadingComponent
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

        //constructor
        public LoadingComponent(string type)
        {
            if (type == "paymentsDue")
            {
                NavDisplayValue = "Payments Due";
                RoutePath = "/paymentsdue";
                Glyph = "inbox";
                PageTitle = "Credit Card Statements";
                DataLoading = false;
                ColumnDisplayTitles = new string[] {
                    "Statement Date",
                    "Payment Due Date",
                    "Statement Balance",
                    "Minimum Payment",
                    "Paid Status"
                };
                JsonTitleValues = new string[] {
                    "IssueDate",
                    "DueDate",
                    "Balance",
                    "MinPayment",
                    "PaidStatus"
                };
                //Data = tableData;
            }
            else if (type == "ynabAccounts")
            {
                NavDisplayValue = "Ynab Accounts";
                RoutePath = "/ynabaccountbalances";
                Glyph = "piggy-bank";
                PageTitle = "Ynab Account Balances";
                DataLoading = false;
                ColumnDisplayTitles = new string[] {
                    "Account Name",
                    "Account Balance",
                    "Account Type"
                };
                JsonTitleValues = new string[] {
                    "Name",
                    "Balance",
                    "Type"
                };
            }
            else if (type == "creditCards")
            {
                NavDisplayValue = "Credit Card";
                RoutePath = "/creditcard";
                Glyph = "credit-card";
                PageTitle = "Full Credit Card Data";
                DataLoading = false;
                ColumnDisplayTitles = new string[] {
                    "Account Name",
                    "Statement Date",
                    "Payment Due Date",
                    "Statement Balance",
                    "Minimum Payment",
                    "YNAB Account Balance"
                };
                JsonTitleValues = new string[] {
                    "Name",
                    "IssueDate",
                    "DueDate",
                    "Balance",
                    "MinPayment",
                    "balance"
                };
            }
        }
    }
}