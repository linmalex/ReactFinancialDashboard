using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReactFinancialDashboard.Data;
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
            PersonalData personalData = _context.PersonalDatas.Where(pd => pd.ID == ID).FirstOrDefault();
            DataVM data = new DataVM(personalData);
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
            return JsonConvert.SerializeObject(statements);
        }

        [HttpGet("[action]")]
        public string UpdateLocalYnabData(int ID)
        {
            try
            {
                using (_context)
                {
                    List<YnabAccount> accountsList = YnabAccount.GetAPIYnabAccountsList(_context, ID);
                    foreach (YnabAccount item in accountsList)
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
                    List<YnabAccount> serverAccounts = _context.YnabAccounts.Where(y => y.PersonalData == personalData).ToList();
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
            List<YnabAccount> serverAccounts = _context.YnabAccounts.Where(y => y.PersonalData == personalData).ToList();
            string json = JsonConvert.SerializeObject(serverAccounts);
            return json;
        }
        #endregion

        #region //* POST actions -----------------------------------------------------------------------
        //* uses state serverData to generate render Route and LoadingComponents
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