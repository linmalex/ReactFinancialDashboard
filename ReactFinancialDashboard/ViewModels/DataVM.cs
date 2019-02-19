using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.ViewModels
{
    public partial class DataVM
    {
        [JsonProperty("currentBudgetID")]
        public string CurrentBudgetId { get; set; }

        [JsonProperty("navDisplayValues")]
        public string NavDisplayValues { get; set; }

        [JsonProperty("routePath")]
        public string RoutePath { get; set; }

        [JsonProperty("componentsList")]
        public List<LoadingComponent> ComponentsList { get; set; }

        public DataVM(string YnabData)
        {
            CurrentBudgetId = "ee4a0a66-fa5a-4838-9ab4-3f8f3f2103ed";
            NavDisplayValues = "Lindsay's Financial Dashboard";
            RoutePath = "/";
            ComponentsList = new List<LoadingComponent>()
            {
                new LoadingComponent("paymentsDue", YnabData),
                new LoadingComponent("ynabAccounts", YnabData),
                new LoadingComponent("creditCards", YnabData)

            };
        }

    }

    public partial class LoadingComponent
    {
        [JsonProperty("navDisplayValues")]
        public string NavDisplayValues { get; set; }

        [JsonProperty("routePath")]
        public string RoutePath { get; set; }

        [JsonProperty("glyph")]
        public string Glyph { get; set; }

        [JsonProperty("loadingData")]
        public LoadingData LoadingData { get; set; }

        [JsonProperty("tableData")]
        public TableData TableData { get; set; }

        public LoadingComponent(string type, string YnabData)
        {
            if (type == "paymentsDue")
            {
                NavDisplayValues = "Payments Due";
                RoutePath = "/paymentsdue";
                Glyph = "inbox";
                LoadingData = new LoadingData(type);
                TableData = new TableData(type);
            }
            else if (type == "ynabAccounts")
            {
                NavDisplayValues = "Ynab Accounts";
                RoutePath = "/ynabaccountbalances";
                Glyph = "piggy-bank";
                LoadingData = new LoadingData(type);
                TableData = new TableData(type);
            }
            else if (type == "creditCards")
            {
                NavDisplayValues = "Credit Card";
                RoutePath = "/creditcard";
                Glyph = "credit-card";
                LoadingData = new LoadingData(type);
                TableData = new TableData(type);
            }
        }
    }

    public partial class LoadingData
    {
        [JsonProperty("pageTitle")]
        public string PageTitle { get; set; }

        [JsonProperty("dataLoading")]
        public bool DataLoading { get; set; }

        public LoadingData(string type)
        {
            if (type == "paymentsDue")
            {
                PageTitle = "Credit Card Statements";
                DataLoading = false;
            }
            else if (type == "ynabAccounts")
            {
                PageTitle = "Ynab Account Balances";
                DataLoading = false;
            }
            else if (type == "creditCards")
            {
                PageTitle = "Full Credit Card Data";
                DataLoading = false;
            }
        }
    }

    public partial class TableData
    {
        [JsonProperty("columnDisplayTitles")]
        public string[] ColumnDisplayTitles { get; set; }

        [JsonProperty("jsonTitleValues")]
        public string[] JsonTitleValues { get; set; }

        [JsonProperty("data")]
        public string[] Data { get; set; }

        public TableData(string type)
        {
            if (type == "paymentsDue")
            {
                ColumnDisplayTitles = new string[]
                {
                        "Statement Date",
                        "Payment Due Date",
                        "Statement Balance",
                        "Minimum Payment",
                        "Paid Status"
                };
                JsonTitleValues = new string[]
                {
                        "IssueDate",
                        "DueDate",
                        "Balance",
                        "MinPayment",
                        "PaidStatus"
                };
            }
            else if (type == "ynabAccounts")
            {
                ColumnDisplayTitles = new string[]
                {
                        "Account Name","Account Balance","Account Type"
                };
                JsonTitleValues = new string[]
                {
                        "Name", "Balance", "Type"
                };

            }
            else if (type == "creditCards")
            {
                ColumnDisplayTitles = new string[]
                {
                    "Account Name","Statement Date","Payment Due Date","Statement Balance","Minimum Payment","YNAB Account Balance"
                };
                JsonTitleValues = new string[]
                {
                    "Name","IssueDate","DueDate","Balance","MinPayment","balance"
                };
            }
        }
    }
}

