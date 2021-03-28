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
    public class SalesOrderLineController : ControllerBase
    {
        private readonly SalesOrderContext _context;

        public SalesOrderLineController(SalesOrderContext context)
        {
            _context = context;
        }

        // GET: api/SalesOrderLine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesOrderLine>>> GetSalesOrderLines()
        {
            return await _context.SalesOrderLines.AsNoTracking()
                .Include(_ => _.SalesOrder)
                    .ThenInclude(_ => _.Customer)
                .Include(_ => _.SalesItemPrice)
                    .ThenInclude(_ => _.SalesItem)
                .Include(_ => _.SalesItemPrice)
                    .ThenInclude(_ => _.UoM)
                .ToListAsync();
        }

        // GET: api/SalesOrderLine/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SalesOrderLine>>> GetSalesOrderLine(int id)
        {
            //var salesOrderLine = await _context.SalesOrderLines.FindAsync(id);

            //var salesOrderLines = await _context.SalesOrderLines.AsNoTracking()
            //    .Include(_ => _.SalesOrder)
            //        .ThenInclude(_ => _.Customer)
            //    .Include(_ => _.SalesItemPrice)
            //        .ThenInclude(_ => _.SalesItem)
            //    .Include(_ => _.SalesItemPrice)
            //        .ThenInclude(_ => _.UoM)
            //    .ToListAsync();

            return await _context.SalesOrderLines.AsNoTracking()
                .Include(_ => _.SalesOrder)
                    .ThenInclude(_ => _.Customer)
                .Include(_ => _.SalesItemPrice)
                    .ThenInclude(_ => _.SalesItem)
                .Include(_ => _.SalesItemPrice)
                    .ThenInclude(_ => _.UoM)
                .Where(_ => _.SalesOrder.SalesOrderId == id)
                .ToListAsync();

            //var salesOrderLine = salesOrderLines.Where(_ => _.SalesOrder.SalesOrderId == id).;

            //if (salesOrderLines == null)
            //{
            //    return NotFound();
            //}

            //return salesOrderLines;
        }

        // PUT: api/SalesOrderLine/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesOrderLine(int id, SalesOrderLine salesOrderLine)
        {
            if (id != salesOrderLine.SalesOrderLineId)
            {
                return BadRequest();
            }

            _context.Entry(salesOrderLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesOrderLineExists(id))
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

        // POST: api/SalesOrderLine
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesOrderLine>> PostSalesOrderLine(SalesOrderLine salesOrderLine)
        {
            _context.SalesOrderLines.Add(salesOrderLine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesOrderLine", new { id = salesOrderLine.SalesOrderLineId }, salesOrderLine);
        }

        // DELETE: api/SalesOrderLine/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesOrderLine(int id)
        {
            var salesOrderLine = await _context.SalesOrderLines.FindAsync(id);
            if (salesOrderLine == null)
            {
                return NotFound();
            }

            _context.SalesOrderLines.Remove(salesOrderLine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesOrderLineExists(int id)
        {
            return _context.SalesOrderLines.Any(e => e.SalesOrderLineId == id);
        }
    }
}
