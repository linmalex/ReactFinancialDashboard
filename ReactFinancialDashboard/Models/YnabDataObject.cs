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
        #region Properties
        public int ID { get; set; }
        public string Server_knowledge { get; set; }
        public DateTime DateRetrieved { get; set; }
        [NotMapped]
        public List<Transaction> Transactions { get; set; }
        [NotMapped]
        public List<YnabAccount> YnabAccounts { get; set; }
        [NotMapped]
        public List<CategoryGroup> CategoryGroups { get; set; }
        #endregion

        #region Constructors
        public YnabDataObject() { }
        ///data object to hold all new YNAB data for purposes of obtaining data at startup
        public YnabDataObject(ApplicationDbContext context, bool requestAllData)
        {
            string uri = requestAllData ? SetURI_AllTransactions() : SetURI_RecentTransactions(GetLastKnowledge(context.DataObjects.ToList()));
            JObject transactionsJSON = JsonObject(uri).Result;
            Server_knowledge = JsonToServerKnowledge(transactionsJSON);
            Transactions = JsonToTransactions(transactionsJSON);
            YnabAccounts = GetAccounts();
            DateRetrieved = DateTime.Now;
            CategoryGroups = GetCategoryGroups();
        }

        public static List<CategoryGroup> GetCategoryGroups()
        {
            string uri = SetURI_Categories();
            JObject budgetDataJSON = JsonObject(uri).Result;
            List<CategoryGroup> categoryGroups = JsonToCategoryGroups(budgetDataJSON);
            return categoryGroups;
        }
        public static List<YnabAccount> GetAccounts()
        {
            PersonalData personalData = new PersonalData();
            string uri = SetURI_Accounts();
            JObject jsonBudgetData = JsonObject(uri).Result;
            //todo maybe it doesn't like the context here?
            List<YnabAccount> ynabAccountsList = JsonToAccounts(jsonBudgetData);
            return ynabAccountsList;
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

        public static List<YnabAccount> JsonToAccounts(JObject budgetResponseData)
        {
            List<JToken> jAccountTokens = budgetResponseData["data"]["accounts"].Children().ToList();
            List<YnabAccount> ynabAccountsList = new List<YnabAccount>();
            foreach (JToken jToken in jAccountTokens)
            {
                YnabAccount ynabAccount = jToken.ToObject<YnabAccount>();
                ynabAccount.UpdateSelf();
                if (ynabAccount.Type == "Credit Card")
                {
                    YnabLiabilityAccount newYnabAccount = new YnabLiabilityAccount(ynabAccount);
                    ynabAccountsList.Add(newYnabAccount);
                }
                else
                {
                    var newYnabAccount = new YnabAssetAccount(ynabAccount);
                    ynabAccountsList.Add(newYnabAccount);
                }
            }
            return ynabAccountsList;
        }
        public static List<CategoryGroup> JsonToCategoryGroups(JObject budgetDataJSON)
        {
            List<JToken> jCatGroupTokens = budgetDataJSON["data"]["category_groups"].Children().ToList();
            List<CategoryGroup> categoryGroupsList = new List<CategoryGroup>();
            foreach (JToken jToken in jCatGroupTokens)
            {
                CategoryGroup catGroup = jToken.ToObject<CategoryGroup>();
                foreach (Category category in catGroup.Categories)
                {
                    category.UpdateSelf();
                }
                categoryGroupsList.Add(catGroup);
            }
            return categoryGroupsList;
        }
        public static string JsonToServerKnowledge(JObject budgetDataJSON)
        {
            string serverKnowledge = budgetDataJSON["data"]["server_knowledge"].ToString();
            return serverKnowledge;
        }
        public static List<Transaction> JsonToTransactions(JObject transactionJSON)
        {
            List<JToken> transactionsJSONTokens = transactionJSON["data"]["transactions"].Children().ToList();
            List<Transaction> newTransactions = new List<Transaction>();
            foreach (JToken jToken in transactionsJSONTokens)
            {
                var transaction = new Transaction();
                transaction = jToken.ToObject<Transaction>();
                transaction.Amount = transaction.Amount / 1000;
                newTransactions.Add(transaction);
            }
            return newTransactions;
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
