using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ReactFinancialDashboard.Models;

namespace ReactFinancialDashboard.Controllers {
    [Route ("api/[controller]")]
    public class YnabAccountController : Controller {
        [HttpGet ("[action]")]
        public List<YnabAccount> YnabAccounts () {
            var budgetID = "ee4a0a66-fa5a-4838-9ab4-3f8f3f2103ed";
            string uri = "https://api.youneedabudget.com/v1/budgets/" + budgetID + "/accounts";
            JObject jsonBudgetData = JsonObject (uri).Result;
            //todo maybe it doesn't like the context here?
            List<YnabAccount> ynabAccountsList = JsonToAccounts (jsonBudgetData);
            return ynabAccountsList;
        }
        public static async Task<JObject> JsonObject (string uri) {
            PersonalData personalData = new PersonalData ();
            personalData.AuthToken = "9b97d868b5b29c476d81f84093e43d63a3447338551727c1bd1bd290ea61bf75";
            HttpClient client = new HttpClient ();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue ("Bearer", personalData.AuthToken);
            JObject transactionData = JObject.Parse (await client.GetStringAsync (uri));
            return transactionData;
        }
        public static List<YnabAccount> JsonToAccounts (JObject budgetResponseData) {
            List<JToken> jAccountTokens = budgetResponseData["data"]["accounts"].Children ().ToList ();
            List<YnabAccount> ynabAccountsList = new List<YnabAccount> ();
            foreach (JToken jToken in jAccountTokens) {
                YnabAccount ynabAccount = jToken.ToObject<YnabAccount> ();
                ynabAccount.UpdateSelf ();
                if (ynabAccount.Type == "Credit Card") {
                    YnabLiabilityAccount newYnabAccount = new YnabLiabilityAccount (ynabAccount);
                    ynabAccountsList.Add (newYnabAccount);
                } else {
                    var newYnabAccount = new YnabAssetAccount (ynabAccount);
                    ynabAccountsList.Add (newYnabAccount);
                }
            }
            return ynabAccountsList;
        }
    }
}