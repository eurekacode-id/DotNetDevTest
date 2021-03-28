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
    public class SalesItemPriceController : ControllerBase
    {
        private readonly SalesOrderContext _context;

        public SalesItemPriceController(SalesOrderContext context)
        {
            _context = context;
        }

        // GET: api/SalesItemPrice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesItemPrice>>> GetSalesItemPrices()
        {
            return await _context.SalesItemPrices.AsNoTracking()
                .Include(_ => _.UoM)
                .Include(_ => _.SalesItem)
                .Include(_ => _.SalesOrderLines)
                    .ThenInclude(_ => _.SalesOrder)
                        .ThenInclude(_ => _.Customer)
                .ToListAsync();
        }

        // GET: api/SalesItemPrice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesItemPrice>> GetSalesItemPrice(int id)
        {
            //var salesItemPrice = await _context.SalesItemPrices.FindAsync(id);
            var salesItemPrices = await _context.SalesItemPrices.AsNoTracking()
                .Include(_ => _.UoM)
                .Include(_ => _.SalesItem)
                .Include(_ => _.SalesOrderLines)
                    .ThenInclude(_ => _.SalesOrder)
                        .ThenInclude(_ => _.Customer)
                .ToListAsync();

            var salesItemPrice = salesItemPrices.Where(_ => _.SalesItemPriceId == id).FirstOrDefault();

            if (salesItemPrice == null)
            {
                return NotFound();
            }

            return salesItemPrice;
        }

        // PUT: api/SalesItemPrice/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesItemPrice(int id, SalesItemPrice salesItemPrice)
        {
            if (id != salesItemPrice.SalesItemPriceId)
            {
                return BadRequest();
            }

            _context.Entry(salesItemPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesItemPriceExists(id))
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

        // POST: api/SalesItemPrice
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesItemPrice>> PostSalesItemPrice(SalesItemPrice salesItemPrice)
        {
            _context.SalesItemPrices.Add(salesItemPrice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesItemPrice", new { id = salesItemPrice.SalesItemPriceId }, salesItemPrice);
        }

        // DELETE: api/SalesItemPrice/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesItemPrice(int id)
        {
            var salesItemPrice = await _context.SalesItemPrices.FindAsync(id);
            if (salesItemPrice == null)
            {
                return NotFound();
            }

            _context.SalesItemPrices.Remove(salesItemPrice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesItemPriceExists(int id)
        {
            return _context.SalesItemPrices.Any(e => e.SalesItemPriceId == id);
        }
    }
}
