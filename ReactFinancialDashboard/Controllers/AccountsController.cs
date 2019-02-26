using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount([FromRoute] string id, [FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != account.ID)
            {
                return BadRequest();
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
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

        private bool AccountExists(string id)
        {
            return _context.YnabAccounts.Any(e => e.ID == id);
        }
    }
}