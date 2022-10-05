using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;

namespace BigOn.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly BigOnDbContext _context;

        public ColorsController(BigOnDbContext context)
        {
            _context = context;
        }

        // GET: api/Colors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductColor>>> GetProductColors()
        {
            return await _context.ProductColors.ToListAsync();
        }

        // GET: api/Colors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductColor>> GetProductColor(int id)
        {
            var productColor = await _context.ProductColors.FindAsync(id);

            if (productColor == null)
            {
                return NotFound();
            }

            return productColor;
        }

        // PUT: api/Colors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductColor(int id, ProductColor productColor)
        {
            if (id != productColor.Id)
            {
                return BadRequest();
            }

            _context.Entry(productColor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductColorExists(id))
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

        // POST: api/Colors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductColor>> PostProductColor(ProductColor productColor)
        {
            _context.ProductColors.Add(productColor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductColor", new { id = productColor.Id }, productColor);
        }

        // DELETE: api/Colors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductColor(int id)
        {
            var productColor = await _context.ProductColors.FindAsync(id);
            if (productColor == null)
            {
                return NotFound();
            }

            _context.ProductColors.Remove(productColor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductColorExists(int id)
        {
            return _context.ProductColors.Any(e => e.Id == id);
        }
    }
}
