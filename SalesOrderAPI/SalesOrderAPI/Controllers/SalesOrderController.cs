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
    public class SalesOrderController : ControllerBase
    {
        private readonly SalesOrderContext _context;

        public SalesOrderController(SalesOrderContext context)
        {
            _context = context;
        }

        // GET: api/SalesOrder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesOrder>>> GetSalesOrders()
        {
            return await _context.SalesOrders.AsNoTracking()
                .Include(_ => _.Customer)
                .Include(_ => _.SalesOrderLines)
                    .ThenInclude(_ => _.SalesItemPrice)
                        .ThenInclude(_ => _.SalesItem)
                .Include(_ => _.SalesOrderLines)
                    .ThenInclude(_ => _.SalesItemPrice)
                        .ThenInclude(_ => _.UoM)
                .ToListAsync();
        }

        // GET: api/SalesOrder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesOrder>> GetSalesOrder(int id)
        {
            //var salesOrder = await _context.SalesOrders.FindAsync(id);

            var salesOrders = await _context.SalesOrders.AsNoTracking()
                .Include(_ => _.Customer)
                .Include(_ => _.SalesOrderLines)
                    .ThenInclude(_ => _.SalesItemPrice)
                        .ThenInclude(_ => _.SalesItem)
                .Include(_ => _.SalesOrderLines)
                    .ThenInclude(_ => _.SalesItemPrice)
                        .ThenInclude(_ => _.UoM)
                .ToListAsync();

            var salesOrder = salesOrders.Where(_ => _.SalesOrderId == id).FirstOrDefault();

            if (salesOrder == null)
            {
                return NotFound();
            }

            return salesOrder;
        }

        // PUT: api/SalesOrder/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesOrder(int id, SalesOrder salesOrder)
        {
            if (id != salesOrder.SalesOrderId)
            {
                return BadRequest();
            }

            _context.Entry(salesOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesOrderExists(id))
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

        // POST: api/SalesOrder
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesOrder>> PostSalesOrder(SalesOrder salesOrder)
        {
            _context.SalesOrders.Add(salesOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesOrder", new { id = salesOrder.SalesOrderId }, salesOrder);
        }

        // DELETE: api/SalesOrder/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesOrder(int id)
        {
            var salesOrder = await _context.SalesOrders.FindAsync(id);
            if (salesOrder == null)
            {
                return NotFound();
            }

            _context.SalesOrders.Remove(salesOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesOrderExists(int id)
        {
            return _context.SalesOrders.Any(e => e.SalesOrderId == id);
        }
    }
}
