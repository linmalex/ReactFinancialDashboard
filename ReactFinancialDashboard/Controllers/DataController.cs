using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReactFinancialDashboard.Data;
using ReactFinancialDashboard.Data.Utilities;
using ReactFinancialDashboard.Interfaces;
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
            List<IViewModel> componentsToRender = new List<IViewModel>()
            {
                new CreditCardStatement(),
                new Account()
            };
            DataVM data = new DataVM(componentsToRender, ID);
            string data1 = JsonConvert.SerializeObject(data);
            return data1;
        }
        #endregion


    }
}