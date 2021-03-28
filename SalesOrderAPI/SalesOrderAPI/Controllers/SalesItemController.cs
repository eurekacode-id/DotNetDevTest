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
    public class SalesItemController : ControllerBase
    {
        private readonly SalesOrderContext _context;

        public SalesItemController(SalesOrderContext context)
        {
            _context = context;
        }

        // GET: api/SalesItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesItem>>> GetSalesItems()
        {
            return await _context.SalesItems.AsNoTracking()
                .Include(_ => _.SalesItemPrices)
                    .ThenInclude(_ => _.UoM)
                .Include(_ => _.SalesItemPrices)
                    .ThenInclude(_ => _.SalesOrderLines)
                        .ThenInclude(_ => _.SalesOrder)
                            .ThenInclude(_ => _.Customer)
                .ToListAsync();
        }

        // GET: api/SalesItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesItem>> GetSalesItem(int id)
        {
            //var salesItem = await _context.SalesItems.FindAsync(id);

            var salesItems = await _context.SalesItems.AsNoTracking()
                .Include(_ => _.SalesItemPrices)
                    .ThenInclude(_ => _.UoM)
                .Include(_ => _.SalesItemPrices)
                    .ThenInclude(_ => _.SalesOrderLines)
                        .ThenInclude(_ => _.SalesOrder)
                            .ThenInclude(_ => _.Customer)
                .ToListAsync();

            var salesItem = salesItems.Where(_ => _.SalesItemId == id).FirstOrDefault();

            if (salesItem == null)
            {
                return NotFound();
            }

            return salesItem;
        }

        // PUT: api/SalesItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesItem(int id, SalesItem salesItem)
        {
            if (id != salesItem.SalesItemId)
            {
                return BadRequest();
            }

            _context.Entry(salesItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesItemExists(id))
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

        // POST: api/SalesItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesItem>> PostSalesItem(SalesItem salesItem)
        {
            _context.SalesItems.Add(salesItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesItem", new { id = salesItem.SalesItemId }, salesItem);
        }

        // DELETE: api/SalesItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesItem(int id)
        {
            var salesItem = await _context.SalesItems.FindAsync(id);
            if (salesItem == null)
            {
                return NotFound();
            }

            _context.SalesItems.Remove(salesItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesItemExists(int id)
        {
            return _context.SalesItems.Any(e => e.SalesItemId == id);
        }
    }
}
