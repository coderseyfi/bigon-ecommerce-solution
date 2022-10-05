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
    public class FaqsController : Controller
    {
        private readonly BigOnDbContext db;

        public FaqsController(BigOnDbContext db)
        {
            this.db = db;
        }

        // GET: Admin/Faqs
        public async Task<IActionResult> Index()
        {
            return View(await db.Faqs.ToListAsync());
        }

        // GET: Admin/Faqs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = await db.Faqs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faq == null)
            {
                return NotFound();
            }

            return View(faq);
        }

        // GET: Admin/Faqs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Faqs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Question,Answer,Id,CreatedDate,DeletedDate")] Faq faq)
        {
            if (ModelState.IsValid)
            {
                db.Add(faq);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faq);
        }

        // GET: Admin/Faqs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = await db.Faqs.FindAsync(id);
            if (faq == null)
            {
                return NotFound();
            }
            return View(faq);
        }

        // POST: Admin/Faqs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Question,Answer,Id")] Faq faq)
        {
            if (id != faq.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(faq);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaqExists(faq.Id))
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
            return View(faq);
        }

        // POST: Admin/Faqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faq = await db.Faqs.FindAsync(id);
            db.Faqs.Remove(faq);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaqExists(int id)
        {
            return db.Faqs.Any(e => e.Id == id);
        }
    }
}
