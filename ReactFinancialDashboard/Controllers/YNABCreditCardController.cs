using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ReactFinancialDashboard.Models;
using ReactFinancialDashboard.Data;
using Newtonsoft.Json;

namespace ReactFinancialDashboard.Controllers
{
    [Route("api/[controller]")]
    public class YNABCreditCardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YNABCreditCardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public JObject YNABAccountsJson()
        {
            ApplicationDbContext context = _context;
            int personalBudgetID = 1;
            PersonalData personalData = context.PersonalDatas.Where(x => x.ID == personalBudgetID).FirstOrDefault();
            string uri = SetURI_Accounts(personalData);

            JObject jsonBudgetData = JsonObject(uri, personalData).Result;
            return jsonBudgetData;
        }

        [HttpGet("[action]")]
        public JObject ServerStatements()
        {
            ApplicationDbContext context = _context;
            List<CreditCardStatement> statements = context.CreditCardStatements.ToList();
            string jsonoutput = JsonConvert.SerializeObject(statements);
            JObject jObject2 = new JObject(statements);
            return jObject2;
        }

        public static string SetURI_Accounts(PersonalData personalData)
        {
            string uri = "https://api.youneedabudget.com/v1/budgets/" + personalData.BudgetID + "/accounts";
            return uri;
        }
        public async Task<JObject> JsonObject(string uri, PersonalData personalData)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", personalData.AuthToken);
            JObject transactionData = JObject.Parse(await client.GetStringAsync(uri));
            return transactionData;
        }
    }
}