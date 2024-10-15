using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP02.Data;
using TP02.Models;

namespace TP02.Controllers
{
    public class BillsOfLadingController : Controller
    {
        private readonly TP02DbContext _context;

        public BillsOfLadingController(TP02DbContext context)
        {
            _context = context;
        }

        // GET: BillsOfLading
        public async Task<IActionResult> Index()
        {
            return View(await _context.BillOfLadings.ToListAsync());
        }

        // GET: BillsOfLading/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billOfLading = await _context.BillOfLadings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billOfLading == null)
            {
                return NotFound();
            }

            return View(billOfLading);
        }

        // GET: BillsOfLading/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BillsOfLading/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,Consignee,Navio")] BillOfLading billOfLading)
        {
            if (ModelState.IsValid)
            {
                _context.Add(billOfLading);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(billOfLading);
        }

        // GET: BillsOfLading/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billOfLading = await _context.BillOfLadings.FindAsync(id);
            if (billOfLading == null)
            {
                return NotFound();
            }
            return View(billOfLading);
        }

        // POST: BillsOfLading/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,Consignee,Navio")] BillOfLading billOfLading)
        {
            if (id != billOfLading.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billOfLading);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillOfLadingExists(billOfLading.Id))
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
            return View(billOfLading);
        }

        // GET: BillsOfLading/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billOfLading = await _context.BillOfLadings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billOfLading == null)
            {
                return NotFound();
            }

            return View(billOfLading);
        }

        // POST: BillsOfLading/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var billOfLading = await _context.BillOfLadings.FindAsync(id);
            if (billOfLading != null)
            {
                _context.BillOfLadings.Remove(billOfLading);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillOfLadingExists(int id)
        {
            return _context.BillOfLadings.Any(e => e.Id == id);
        }
    }
}
