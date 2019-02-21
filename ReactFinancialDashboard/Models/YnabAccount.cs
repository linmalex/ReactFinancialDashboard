using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReactFinancialDashboard.Data;

namespace ReactFinancialDashboard.Models {
    public class YnabAccount {
        #region Properties
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        [DataType (DataType.Currency)]
        public double Balance { get; set; }

        [DataType (DataType.Currency)]
        public double Cleared_balance { get; set; }
        public string Note { get; set; }

        [DataType (DataType.Currency)]
        public double Uncleared_balance { get; set; }
        public string Transfer_payee_id { get; set; }
        public bool Deleted { get; set; }
        public bool On_budget { get; set; }
        public bool Closed { get; set; }

        //public IList<CreditCardStatement> CreditCardStatements { get; set; }

        public PersonalData PersonalData { get; set; }
        #endregion

        /// <summary>
        /// Calls YNAB API for JSON data
        /// </summary>
        /// <param name="personalData"></param>
        /// <returns>JObject containing new API data</returns>
        public static async Task<JObject> GetAPIYnabAccountsJSON (PersonalData personalData) {
            HttpClient client = new HttpClient ();
            string uri = "https://api.youneedabudget.com/v1/budgets/" + personalData.BudgetID + "/accounts";
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue ("Bearer", personalData.AuthToken);
            JObject transactionData = JObject.Parse (await client.GetStringAsync (uri));
            return transactionData;
        }
        
        /// <summary>
        /// Gets new YNAB data as JSON and converts it to List
        /// </summary>
        /// <param name="context"></param>
        /// <param name="personalBudgetID"></param>
        /// <returns></returns>
        public static List<YnabAccount> GetAPIYnabAccountsList (ApplicationDbContext context, int personalBudgetID) {
            List<YnabAccount> accounts = new List<YnabAccount> ();

            PersonalData personalData = context.PersonalDatas.Where (x => x.ID == personalBudgetID).FirstOrDefault ();
            JToken jsonAccountsData = GetAPIYnabAccountsJSON (personalData).Result["data"]["accounts"];

            foreach (JToken jAccount in jsonAccountsData) //item is the account
            {
                UpdateJAccountValues (jAccount);
                YnabAccount account = jAccount.ToObject<YnabAccount> ();
                account.PersonalData = personalData;
                accounts.Add (account);
            }

            return accounts;
        }

        /// <summary>
        /// Converts a given jtoken's monetary milliunit values to standard units
        /// </summary>
        /// <param name="jAccount"></param>
        /// <returns></returns>
        public static JToken UpdateJAccountValues (JToken jAccount) {
            jAccount["balance"] = ((double) jAccount["balance"]) / 1000;
            jAccount["cleared_balance"] = ((double) jAccount["cleared_balance"]) / 1000;
            jAccount["uncleared_balance"] = ((double) jAccount["uncleared_balance"]) / 1000;
            jAccount["type"] = Utilities.SplitStrings.SplitString ((string) jAccount["type"]);
            return jAccount;
        }

        /// <summary>
        /// Updates local database with new YNAB account values
        /// </summary>
        /// <param name="context"></param>
        /// <param name="personalBudgetID"></param>
        public static void UpdateAccountsDatabase (ApplicationDbContext context, int personalBudgetID) {
            try {
                using (context) {
                    List<YnabAccount> accountsList = GetAPIYnabAccountsList(context, personalBudgetID);
                    foreach (YnabAccount item in accountsList) {
                        if (context.YnabAccounts.Contains (item)) {
                            context.Update (item);
                        } else {
                            context.Add (item);
                        }
                    }
                    context.SaveChanges ();
                }
                // eslint-disable-next-line
            } catch (Exception) {
                throw;
            }
        }
    }
}