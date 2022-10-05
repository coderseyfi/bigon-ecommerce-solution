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
    public class SizesController : Controller
    {
        private readonly BigOnDbContext db;

        public SizesController(BigOnDbContext db)
        {
            this.db = db;
        }

        // GET: Admin/Sizes
        public async Task<IActionResult> Index()
        {
            return View(await db.ProductSizes.ToListAsync());
        }

        // GET: Admin/Sizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSize = await db.ProductSizes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productSize == null)
            {
                return NotFound();
            }

            return View(productSize);
        }

        // GET: Admin/Sizes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,SmallName,Id,CreatedDate,DeletedDate")] ProductSize productSize)
        {
            if (ModelState.IsValid)
            {
                db.Add(productSize);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productSize);
        }

        // GET: Admin/Sizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSize = await db.ProductSizes.FindAsync(id);
            if (productSize == null)
            {
                return NotFound();
            }
            return View(productSize);
        }

        // POST: Admin/Sizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,SmallName,Id")] ProductSize productSize)
        {
            if (id != productSize.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(productSize);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSizeExists(productSize.Id))
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
            return View(productSize);
        }

       
        // POST: Admin/Sizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productSize = await db.ProductSizes.FindAsync(id);
            db.ProductSizes.Remove(productSize);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSizeExists(int id)
        {
            return db.ProductSizes.Any(e => e.Id == id);
        }
    }
}
