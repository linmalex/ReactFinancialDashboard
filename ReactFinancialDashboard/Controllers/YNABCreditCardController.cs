using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReactFinancialDashboard.Data;
using ReactFinancialDashboard.Models;

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
        public IActionResult CreateStatement()
        {
            ApplicationDbContext context = _context;
            List<YnabAccount> serverAccounts = context.YnabAccounts.ToList();
            string json = JsonConvert.SerializeObject(serverAccounts);
            var jsonresult = new JsonResult(json);
            return jsonresult;
        }
    }
}