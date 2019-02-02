using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactFinancialDashboard.Data;
using ReactFinancialDashboard.Models;

namespace ReactFinancialDashboard.Controllers {
    [Route ("api/[controller]")]
    public class TransactionController : Controller {
        private readonly ApplicationDbContext _context;

        public TransactionController (ApplicationDbContext context) {
            _context = context;
        }

        public void GetYnabTransactions (ApplicationDbContext context) {
            bool requestAllData = (context.Transactions.Count () == 0) ? requestAllData = true : requestAllData = false;
            DataYnab newYnabData = new DataYnab (context, requestAllData);
            foreach (Transaction transaction in newYnabData.Transactions) {
                transaction.Data = newYnabData;
                if (context.Transactions.Contains (transaction)) {
                    context.Transactions.Update (transaction);
                } else {
                    context.Transactions.Add (transaction);
                }
            }

        }

        public IActionResult Index () {
            return View ();
        }
    }
}