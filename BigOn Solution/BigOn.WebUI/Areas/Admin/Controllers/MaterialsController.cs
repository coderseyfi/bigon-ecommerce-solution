using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;

namespace BigOn.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MaterialsController : Controller
    {
        private readonly BigOnDbContext db;

        public MaterialsController(BigOnDbContext db)
        {
            this.db = db;
        }

        // GET: Admin/Materials
        public async Task<IActionResult> Index()
        {
            return View(await db.ProductMaterials.ToListAsync());
        }

        // GET: Admin/Materials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMaterial = await db.ProductMaterials
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productMaterial == null)
            {
                return NotFound();
            }

            return View(productMaterial);
        }

        // GET: Admin/Materials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Materials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,CreatedDate,DeletedDate")] ProductMaterial productMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Add(productMaterial);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productMaterial);
        }

        // GET: Admin/Materials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMaterial = await db.ProductMaterials.FindAsync(id);
            if (productMaterial == null)
            {
                return NotFound();
            }
            return View(productMaterial);
        }

        // POST: Admin/Materials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] ProductMaterial productMaterial)
        {
            if (id != productMaterial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(productMaterial);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductMaterialExists(productMaterial.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productMaterial);
        }

       

        // POST: Admin/Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productMaterial = await db.ProductMaterials.FindAsync(id);
            db.ProductMaterials.Remove(productMaterial);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductMaterialExists(int id)
        {
            return db.ProductMaterials.Any(e => e.Id == id);
        }
    }
}
