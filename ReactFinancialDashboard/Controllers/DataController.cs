using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReactFinancialDashboard.Data;
using ReactFinancialDashboard.Data.Utilities;
using ReactFinancialDashboard.Models;
using ReactFinancialDashboard.ViewModels;

namespace ReactFinancialDashboard.Controllers
{
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DataController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region //* GET actions -----------------------------------------------------------------------
        [HttpGet("[action]")]
        public string SetInitialState(int ID)
        {
            DataVM data = new DataVM(id: ID);
            string data1 = JsonConvert.SerializeObject(data);
            return data1;
        }

        /// <summary>
        /// Get local statements with a given PersonalData ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public string SetServerStatements(int ID)
        {
            List<CreditCardStatement> statements = _context.CreditCardStatements.Where(y => y.PersonalDataID == ID).ToList();
            List<string> creditCardNames = new List<string>() {
                "DueDate",
                "IssueDate",
                "Balance",
                "MinPayment",
                "PaidStatus"
            };
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new JsonPropRenderSettings(true, creditCardNames)
            };
            var json = JsonConvert.SerializeObject(statements, settings);
            return json;
        }

        [HttpGet("[action]")]
        public string UpdateLocalYnabData(int ID)
        {
            try
            {
                using (_context)
                {
                    List<Account> accountsList = Account.GetAPIYnabAccountsList(_context, ID);
                    foreach (Account item in accountsList)
                    {
                        if (_context.YnabAccounts.Contains(item))
                        {
                            _context.Update(item);
                        }
                        else
                        {
                            _context.Add(item);
                        }
                    }
                    PersonalData personalData = _context.PersonalDatas.Where(x => x.ID == ID).FirstOrDefault();
                    List<Account> serverAccounts = _context.YnabAccounts.Where(y => y.PersonalData == personalData).ToList();
                    _context.SaveChanges();
                    string json = JsonConvert.SerializeObject(serverAccounts);
                    return json;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("[action]")]
        public string SetYnabAccountsJson(int ID)
        {
            PersonalData personalData = _context.PersonalDatas.Where(x => x.ID == ID).FirstOrDefault();
            List<Account> serverAccounts = _context.YnabAccounts.Where(y => y.PersonalData == personalData).ToList();
            List<string> accountNames = new List<string>() {
                "Name",
                "Type",
                "Balance",
            };
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new JsonPropRenderSettings(true, accountNames)
            };
            var json = JsonConvert.SerializeObject(serverAccounts, settings);
            return json;
        }
        #endregion

        #region //* POST actions -----------------------------------------------------------------------
        //* uses state serverData to generate render Route and BodyComponents
        [HttpPost("[action]")]
        public IActionResult CreateStatement([FromForm] CreditCardStatement statement)
        {
            ApplicationDbContext context = _context;
            statement.PaidStatus = "Unpaid";
            context.Add(statement);
            context.SaveChanges();
            JsonResult result = new JsonResult("Statement Added");
            return result;
        }
        #endregion

    }
}