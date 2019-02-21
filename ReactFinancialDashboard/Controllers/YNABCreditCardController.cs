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
    public class YNABCreditCardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YNABCreditCardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public string DbYNABAccountsJson()
        {
            ApplicationDbContext context = _context;
            List<YnabAccount> serverAccounts = context.YnabAccounts.ToList();
            string json = JsonConvert.SerializeObject(serverAccounts);
            return json;
        }

        [HttpGet("[action]")]
        public string ServerStatements()
        {
            ApplicationDbContext context = _context;
            List<CreditCardStatement> statements = context.CreditCardStatements.ToList();
            return JsonConvert.SerializeObject(statements);
        }

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

        [HttpGet("[action]")]
        public ActionResult GetNewYnabData()
        {
            YnabAccount.UpdateAccountsDatabase(_context, 1);
            JsonResult result = new JsonResult("Success");
            return result;
        }

        [HttpGet("[action]")]
        public string RenderState()
        {
            //string ynabData = DbYNABAccountsJson();
            string[] ynabData = new string[1];
            DataVM data = new DataVM(ynabData);
            string data1 = JsonConvert.SerializeObject(data);
            return data1;
        }
    }
}