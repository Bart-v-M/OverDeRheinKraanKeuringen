using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OverDeRheinKraanKeuringen.Data;
using OverDeRheinKraanKeuringen.Models;

namespace OverDeRheinKraanKeuringen.Controllers
{
    public class CableChecklistsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CableChecklistsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CableChecklists
        public async Task<IActionResult> Index()
        {
            var x = await _context.CableChecklists.Include(m => m.DamageTypes).ToListAsync();
            return View(x);
        }

        // GET: CableChecklists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cableChecklist = await _context.CableChecklists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cableChecklist == null)
            {
                return NotFound();
            }

            return View(cableChecklist);
        }

        // GET: CableChecklists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CableChecklists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Breakage_6D,Breakage_30D,DamageOutside,DamageCorrosion,ReducedCableDiameter,PositionMeasuringPoints,DamageTotal")] CableChecklist cableChecklist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cableChecklist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cableChecklist);
        }

        // GET: CableChecklists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cableChecklist = await _context.CableChecklists.FindAsync(id);
            if (cableChecklist == null)
            {
                return NotFound();
            }
            return View(cableChecklist);
        }

        // POST: CableChecklists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Breakage_6D,Breakage_30D,DamageOutside,DamageCorrosion,ReducedCableDiameter,PositionMeasuringPoints,DamageTotal")] CableChecklist cableChecklist)
        {
            if (id != cableChecklist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cableChecklist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CableChecklistExists(cableChecklist.Id))
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
            return View(cableChecklist);
        }

        // GET: CableChecklists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cableChecklist = await _context.CableChecklists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cableChecklist == null)
            {
                return NotFound();
            }

            return View(cableChecklist);
        }

        // POST: CableChecklists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cableChecklist = await _context.CableChecklists.Include(m => m.DamageTypes).Where(a => a.Id == id).FirstOrDefaultAsync();
            _context.CableChecklists.Remove(cableChecklist);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CableChecklistExists(int id)
        {
            return _context.CableChecklists.Any(e => e.Id == id);
        }
    }
}
