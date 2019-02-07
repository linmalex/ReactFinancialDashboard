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
        public string YNABAccountsJson()
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
    }
}