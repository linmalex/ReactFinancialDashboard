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
        public string SetInitialState()
        {
            //string ynabData = DbYNABAccountsJson();
            string[] ynabData = new string[1];
            DataVM data = new DataVM();
            string data1 = JsonConvert.SerializeObject(data);
            return data1;
        }

        [HttpGet("[action]")]
        public string SetServerStatements(int ID)
        {
            ApplicationDbContext context = _context;
            PersonalData personalData = context.PersonalDatas.Where(x => x.ID == ID).FirstOrDefault();
            List<YnabAccount> serverAccounts = context.YnabAccounts.Where(y => y.PersonalData == personalData).ToList();
            List<CreditCardStatement> statements = context.CreditCardStatements.Where(y => y.PersonalData == personalData).ToList();
            return JsonConvert.SerializeObject(statements);
        }

        [HttpGet("[action]")]
        public ActionResult UpdateLocalYnabData()
        {
            YnabAccount.UpdateAccountsDatabase(_context, 1);
            JsonResult result = new JsonResult("Success");
            return result;
        }

        [HttpGet("[action]")]
        public string SetYnabAccountsJson(int ID)
        {
            ApplicationDbContext context = _context;
            PersonalData personalData = context.PersonalDatas.Where(x => x.ID == ID).FirstOrDefault();
            List<YnabAccount> serverAccounts = context.YnabAccounts.Where(y => y.PersonalData == personalData).ToList();
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