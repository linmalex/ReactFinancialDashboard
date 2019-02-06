using Newtonsoft.Json.Linq;
using ReactFinancialDashboard.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReactFinancialDashboard.Models
{
    public class YnabDataObject
    {
        public int ID { get; set; }
        public string Server_knowledge { get; set; }
        public DateTime DateRetrieved { get; set; }

        #region Constructors
        public YnabDataObject() { }
        ///data object to hold all new YNAB data for purposes of obtaining data at startup
        public YnabDataObject(ApplicationDbContext context, bool requestAllData)
        {
            string uri = requestAllData ? SetURI_AllTransactions() : SetURI_RecentTransactions(GetLastKnowledge(context.DataObjects.ToList()));
            JObject transactionsJSON = JsonObject(uri).Result;
            Server_knowledge = JsonToServerKnowledge(transactionsJSON);
            DateRetrieved = DateTime.Now;
        }

        public static string GetLastKnowledge(List<YnabDataObject> dataObjects)
        {
            string lastKnowledge = dataObjects.Max(x => x.Server_knowledge);
            return lastKnowledge;
        }

        public static async Task<JObject> JsonObject(string uri)
        {
            PersonalData personalData = new PersonalData();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", personalData.AuthToken);
            JObject transactionData = JObject.Parse(await client.GetStringAsync(uri));
            return transactionData;
        }

        public static string JsonToServerKnowledge(JObject budgetDataJSON)
        {
            string serverKnowledge = budgetDataJSON["data"]["server_knowledge"].ToString();
            return serverKnowledge;
        }

        public static string SetURI_Accounts()
        {
            PersonalData personalData = new PersonalData();

            string uri = "https://api.youneedabudget.com/v1/budgets/" + personalData.BudgetID + "/accounts";
            return uri;
        }
        public static string SetURI_AllTransactions()
        {
            PersonalData personalData = new PersonalData();
            string uri = "https://api.youneedabudget.com/v1/budgets/" + personalData.BudgetID + "/transactions";
            return uri;
        }
        public static string SetURI_Categories()
        {
            PersonalData personalData = new PersonalData();
            string uri = "https://api.youneedabudget.com/v1/budgets/" + personalData.BudgetID + "/categories";
            return uri;
        }
        public static string SetURI_RecentTransactions(string lastknowledge)
        {
            PersonalData personalData = new PersonalData();
            string uri = "https://api.youneedabudget.com/v1/budgets/" + personalData.BudgetID + "/transactions" + "?last_knowledge_of_server=" + lastknowledge;
            return uri;
        }

        #endregion
    }
}
