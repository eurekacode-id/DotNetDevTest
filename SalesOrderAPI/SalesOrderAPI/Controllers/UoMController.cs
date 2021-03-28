using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesOrderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesOrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UoMController : ControllerBase
    {
        private readonly SalesOrderContext _context;

        public UoMController(SalesOrderContext context)
        {
            _context = context;
        }

        // GET: api/UoM
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UoM>>> GetUoMs()
        {
            return await _context.UoMs.AsNoTracking()
                .Include(_ => _.SalesItemPrices)
                    .ThenInclude(_ => _.SalesItem)
                .Include(_ => _.SalesItemPrices)
                    .ThenInclude(_ => _.SalesOrderLines)
                        .ThenInclude(_ => _.SalesOrder)
                            .ThenInclude(_ => _.Customer)
                .ToListAsync();
        }

        // GET: api/UoM/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UoM>> GetUoM(int id)
        {
            //var uoM = await _context.UoMs.FindAsync(id);

            var uoMs = await _context.UoMs.AsNoTracking()
                .Include(_ => _.SalesItemPrices)
                    .ThenInclude(_ => _.SalesItem)
                .Include(_ => _.SalesItemPrices)
                    .ThenInclude(_ => _.SalesOrderLines)
                        .ThenInclude(_ => _.SalesOrder)
                            .ThenInclude(_ => _.Customer)
                .ToListAsync();

            var uoM = uoMs.Where(_ => _.UoMId == id).FirstOrDefault();

            if (uoM == null)
            {
                return NotFound();
            }

            return uoM;
        }

        // PUT: api/UoM/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUoM(int id, UoM uoM)
        {
            if (id != uoM.UoMId)
            {
                return BadRequest();
            }

            _context.Entry(uoM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UoMExists(id))
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

        // POST: api/UoM
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UoM>> PostUoM(UoM uoM)
        {
            _context.UoMs.Add(uoM);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUoM", new { id = uoM.UoMId }, uoM);
        }

        // DELETE: api/UoM/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUoM(int id)
        {
            var uoM = await _context.UoMs.FindAsync(id);
            if (uoM == null)
            {
                return NotFound();
            }

            _context.UoMs.Remove(uoM);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UoMExists(int id)
        {
            return _context.UoMs.Any(e => e.UoMId == id);
        }
    }
}
