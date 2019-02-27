using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReactFinancialDashboard.Data;
using ReactFinancialDashboard.Data.Utilities;
using ReactFinancialDashboard.Models;

namespace ReactFinancialDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AccountsController(ApplicationDbContext context)
        {
            _context = context;
        }
        #region GET/PUT/POST---------------------------------------------------------
        // GET: api/Accounts
        [HttpGet]
        public IEnumerable<Account> GetYnabAccounts()
        {
            return _context.YnabAccounts;
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<string> GetAccount([FromRoute] int id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //var account = await _context.YnabAccounts.FindAsync(id);

            //if (account == null)
            //{
            //    return NotFound();
            //}

            //return Ok(account);
            PersonalData personalData = _context.PersonalDatas.Where(x => x.ID == id).FirstOrDefault();
            List<Account> serverAccounts = await _context.YnabAccounts.Where(y => y.PersonalData == personalData).ToListAsync();
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

        //// PUT: api/Accounts/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAccount([FromRoute] string id, [FromBody] Account account)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != account.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(account).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AccountExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
        public string UpdateLocalYnabData(int ID)
        {
            try
            {
                using (_context)
                {
                    string ynabCallResults = CallYnab(ID, "accounts").Result;
                    List<Account> accountsList = JsonToList(ynabCallResults);

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


        [HttpPut("{id}")]
        public string PutAccount([FromRoute] int id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            string ynabCallResults = CallYnab(id, "accounts").Result;

            List<Account> accountsList = JsonToList(ynabCallResults);

            foreach (Account account in accountsList)
            {
                _context.Entry(account).State = EntityState.Modified;
            }
            List<string> accountNames = new List<string>() {
                "Name",
                "Type",
                "Balance",
            };
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new JsonPropRenderSettings(true, accountNames)
            };
            var json = JsonConvert.SerializeObject(accountsList, settings);

            try
            {
                _context.SaveChanges();
                return json;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        // POST: api/Accounts
        [HttpPost]
        public async Task<IActionResult> PostAccount([FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.YnabAccounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = account.ID }, account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = await _context.YnabAccounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.YnabAccounts.Remove(account);
            await _context.SaveChangesAsync();

            return Ok(account);
        }
        #endregion

        private bool AccountExists(string id)
        {
            return _context.YnabAccounts.Any(e => e.ID == id);
        }

        #region YNAB Calls------------------------------------------------------------------------------------
        public async Task<string> CallYnab(int personalBudgetID, string area)
        {
            PersonalData personalData = _context.PersonalDatas.Where(x => x.ID == personalBudgetID).FirstOrDefault();

            try
            {
                HttpClient client = new HttpClient();
                string uristring = "https://api.youneedabudget.com/v1/budgets/" + personalData.BudgetID + "/" + area;
                var uri = new Uri(uristring);
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", personalData.AuthToken);
                return await client.GetStringAsync(uri);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Account> JsonToList(string jsonData)
        {
            JObject transactionData = JObject.Parse(jsonData);
            JToken jsonAccountsData = transactionData["data"]["accounts"];

            List<Account> accounts = new List<Account>();
            foreach (JToken jAccount in jsonAccountsData)
            {
                UpdateJAccountValues(jAccount);
                Account account = jAccount.ToObject<Account>();
                accounts.Add(account);
            }

            return accounts;
        }

        public JToken UpdateJAccountValues(JToken jAccount)
        {
            jAccount["balance"] = ((double)jAccount["balance"]) / 1000;
            jAccount["cleared_balance"] = ((double)jAccount["cleared_balance"]) / 1000;
            jAccount["uncleared_balance"] = ((double)jAccount["uncleared_balance"]) / 1000;
            jAccount["type"] = Utilities.SplitStrings.SplitString((string)jAccount["type"]);
            return jAccount;
        }


        #endregion
    }
}