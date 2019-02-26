using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactFinancialDashboard.Data;
using ReactFinancialDashboard.Models;

namespace ReactFinancialDashboard.Controllers
{
    [Route("api/[controller]")]
    public class CreditCardStatementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreditCardStatementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CreditCardStatements
        [HttpGet]
        public IEnumerable<CreditCardStatement> GetCreditCardStatements()
        {
            return _context.CreditCardStatements;
        }

        // GET: api/CreditCardStatements/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCreditCardStatement([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var creditCardStatement = await _context.CreditCardStatements.FindAsync(id);

            if (creditCardStatement == null)
            {
                return NotFound();
            }



            return Ok(creditCardStatement);
        }

        // PUT: api/CreditCardStatements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreditCardStatement([FromRoute] int id, [FromBody] CreditCardStatement creditCardStatement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != creditCardStatement.ID)
            {
                return BadRequest();
            }

            _context.Entry(creditCardStatement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditCardStatementExists(id))
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

        // POST: api/CreditCardStatements
        [HttpPost]
        public async Task<IActionResult> PostCreditCardStatement([FromBody] CreditCardStatement creditCardStatement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CreditCardStatements.Add(creditCardStatement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCreditCardStatement", new { id = creditCardStatement.ID }, creditCardStatement);
        }

        // DELETE: api/CreditCardStatements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreditCardStatement([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var creditCardStatement = await _context.CreditCardStatements.FindAsync(id);
            if (creditCardStatement == null)
            {
                return NotFound();
            }

            _context.CreditCardStatements.Remove(creditCardStatement);
            await _context.SaveChangesAsync();

            return Ok(creditCardStatement);
        }

        private bool CreditCardStatementExists(int id)
        {
            return _context.CreditCardStatements.Any(e => e.ID == id);
        }
    }
}