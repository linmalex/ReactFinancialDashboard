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

        #region //* POST actions -----------------------------------------------------------------------
        [HttpGet("[action]")]
        public string SetInitialState()
        {
            //string ynabData = DbYNABAccountsJson();
            string[] ynabData = new string[1];
            DataVM data = new DataVM(ynabData);
            string data1 = JsonConvert.SerializeObject(data);
            return data1;
        }

        [HttpGet("[action]")]
        public string SetServerStatements()
        {
            ApplicationDbContext context = _context;
            List<CreditCardStatement> statements = context.CreditCardStatements.ToList();
            return JsonConvert.SerializeObject(statements);
        }

        [HttpGet("[action]")]
        public ActionResult UpdateLocalYnabData()
        {
            YnabAccount.UpdateAccountsDatabase(_context, 2);
            JsonResult result = new JsonResult("Success");
            return result;
        }

        [HttpGet("[action]")]
        public string SetYnabAccountsJson()
        {
            ApplicationDbContext context = _context;
            List<YnabAccount> serverAccounts = context.YnabAccounts.ToList();
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