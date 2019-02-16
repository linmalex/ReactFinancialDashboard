using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReactFinancialDashboard.Controllers;
using ReactFinancialDashboard.Data;
using ReactFinancialDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.ViewModels
{
    public class AppVM
    {
        public string CurrentBudgetID { get; set; }
        public string NavDisplayValues { get; set; }
        public string RoutePath { get; set; }
        public List<LoadingComponentVM> LoadingComponents { get; set; }

        public AppVM(string statementData, string accountData)
        {
            CurrentBudgetID = "ee4a0a66-fa5a-4838-9ab4-3f8f3f2103ed";
            NavDisplayValues = "Lindsay's Financial Dashboard";
            RoutePath = "/";

            LoadingComponents = new List<LoadingComponentVM>();

            LoadingComponentVM paymentsDue = new LoadingComponentVM()
            {
                NavDisplayValue = "Payments Due",
                RoutePath = "/paymentsdue",
                Glyph = "inbox",
                Data = statementData,
                LoadingData = new LoadingData()
                {
                    PageTitle = "Credit Card Statements",
                    DataLoading = true
                },
                TableData = new TableData()
                {
                    ColumnDisplayTitles = new string[]
                    {
                        "Statement Date",
                        "Payment Due Date",
                        "Statement Balance",
                        "Minimum Payment",
                        "Paid Status"
                    },
                    JsonTitleValues = new string[]
                    {
                        "IssueDate",
                        "DueDate",
                        "Balance",
                        "MinPayment",
                        "PaidStatus"
                    }
                }
            };
            LoadingComponentVM ynabAccounts = new LoadingComponentVM()
            {
                NavDisplayValue = "Ynab Accounts",
                RoutePath = "/ynabaccountbalances",
                Glyph = "piggy-bank",
                Data = accountData,
                LoadingData = new LoadingData()
                {
                    PageTitle = "Ynab Account Balances",
                    DataLoading = true
                },
                TableData = new TableData()
                {
                    ColumnDisplayTitles = new string[]
                    {
                        "Account Name","Account Balance","Account Type"
                    },
                    JsonTitleValues = new string[]
                    {
                        "Name", "Balance", "Type"
                    }
                }
            };
            LoadingComponentVM creditCards = new LoadingComponentVM()
            {
                NavDisplayValue = "Credit Card",
                RoutePath = "/creditcard",
                Glyph = "credit-card",
                LoadingData = new LoadingData()
                {
                    PageTitle = "Full Credit Card Data",
                    DataLoading = true
                },
                TableData = new TableData()
                {
                    ColumnDisplayTitles = new string[]
                    {
                        "Account Name","Statement Date","Payment Due Date","Statement Balance","Minimum Payment","YNAB Account Balance"
                    },
                    JsonTitleValues = new string[]
                    {
                        "Name","IssueDate","DueDate","Balance","MinPayment","balance"
                    }
                }
            };


            LoadingComponents.Add(paymentsDue);
            LoadingComponents.Add(ynabAccounts);
            LoadingComponents.Add(creditCards);
        }

    }
}
