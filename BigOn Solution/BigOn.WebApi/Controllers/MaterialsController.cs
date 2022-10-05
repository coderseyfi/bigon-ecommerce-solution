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
    public class MaterialsController : ControllerBase
    {
        private readonly BigOnDbContext _context;

        public MaterialsController(BigOnDbContext context)
        {
            _context = context;
        }

        // GET: api/Materials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductMaterial>>> GetProductMaterials()
        {
            return await _context.ProductMaterials.ToListAsync();
        }

        // GET: api/Materials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductMaterial>> GetProductMaterial(int id)
        {
            var productMaterial = await _context.ProductMaterials.FindAsync(id);

            if (productMaterial == null)
            {
                return NotFound();
            }

            return productMaterial;
        }

        // PUT: api/Materials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductMaterial(int id, ProductMaterial productMaterial)
        {
            if (id != productMaterial.Id)
            {
                return BadRequest();
            }

            _context.Entry(productMaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductMaterialExists(id))
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

        // POST: api/Materials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductMaterial>> PostProductMaterial(ProductMaterial productMaterial)
        {
            _context.ProductMaterials.Add(productMaterial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductMaterial", new { id = productMaterial.Id }, productMaterial);
        }

        // DELETE: api/Materials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductMaterial(int id)
        {
            var productMaterial = await _context.ProductMaterials.FindAsync(id);
            if (productMaterial == null)
            {
                return NotFound();
            }

            _context.ProductMaterials.Remove(productMaterial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductMaterialExists(int id)
        {
            return _context.ProductMaterials.Any(e => e.Id == id);
        }
    }
}
