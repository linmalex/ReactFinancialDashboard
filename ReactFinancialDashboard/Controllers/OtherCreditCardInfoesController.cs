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
    [ApiController]
    public class OtherCreditCardInfoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OtherCreditCardInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/OtherCreditCardInfoes
        [HttpGet]
        public IEnumerable<OtherCreditCardInfo> GetOtherCreditCardInfos()
        {
            return _context.OtherCreditCardInfos;
        }

        // GET: api/OtherCreditCardInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOtherCreditCardInfo([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var otherCreditCardInfo = await _context.OtherCreditCardInfos.FindAsync(id);

            if (otherCreditCardInfo == null)
            {
                return NotFound();
            }

            return Ok(otherCreditCardInfo);
        }

        // PUT: api/OtherCreditCardInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOtherCreditCardInfo([FromRoute] Guid id, [FromBody] OtherCreditCardInfo otherCreditCardInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != otherCreditCardInfo.ID)
            {
                return BadRequest();
            }

            _context.Entry(otherCreditCardInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OtherCreditCardInfoExists(id))
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

        // POST: api/OtherCreditCardInfoes
        [HttpPost]
        public async Task<IActionResult> PostOtherCreditCardInfo([FromBody] OtherCreditCardInfo otherCreditCardInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OtherCreditCardInfos.Add(otherCreditCardInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOtherCreditCardInfo", new { id = otherCreditCardInfo.ID }, otherCreditCardInfo);
        }

        // DELETE: api/OtherCreditCardInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOtherCreditCardInfo([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var otherCreditCardInfo = await _context.OtherCreditCardInfos.FindAsync(id);
            if (otherCreditCardInfo == null)
            {
                return NotFound();
            }

            _context.OtherCreditCardInfos.Remove(otherCreditCardInfo);
            await _context.SaveChangesAsync();

            return Ok(otherCreditCardInfo);
        }

        private bool OtherCreditCardInfoExists(Guid id)
        {
            return _context.OtherCreditCardInfos.Any(e => e.ID == id);
        }
    }
}