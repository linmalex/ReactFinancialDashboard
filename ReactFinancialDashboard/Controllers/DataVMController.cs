using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReactFinancialDashboard.Interfaces;
using ReactFinancialDashboard.Models;
using ReactFinancialDashboard.ViewModels;

namespace ReactFinancialDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataVMController : ControllerBase
    {
        // GET: api/DataVM
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DataVM/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            List<IViewModel> componentsToRender = new List<IViewModel>()
            {
                new CreditCardStatement(),
                new Account()
            };
            DataVM data = new DataVM(componentsToRender, id);
            string data1 = JsonConvert.SerializeObject(data);
            return data1;
        }

        // POST: api/DataVM
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/DataVM/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
