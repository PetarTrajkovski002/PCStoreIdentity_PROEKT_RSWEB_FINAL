using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PCStoreIdentity.Data;
using PCStoreIdentity.Models;
using PCStoreIdentity.ViewModels;

namespace PCStoreIdentity.Controllers
{
    public class RAMsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RAMsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RAMs
        public async Task<IActionResult> Index(string proizvoditel, string tip, string kapacitet)
        {

            var viewmodel = new FilterRAM();
            var rams = _context.RAM.ToList();
            var pronajdeni = new List<RAM>();

            if (!string.IsNullOrEmpty(proizvoditel) || !string.IsNullOrEmpty(tip) || !string.IsNullOrEmpty(kapacitet))
            {
                if (!string.IsNullOrEmpty(proizvoditel) && string.IsNullOrEmpty(tip) && string.IsNullOrEmpty(kapacitet))
                {
                    pronajdeni = _context.RAM.Where(k => k.Proizvoditel.Contains(proizvoditel)).ToList();
                }
                else if (string.IsNullOrEmpty(proizvoditel) && !string.IsNullOrEmpty(tip) && string.IsNullOrEmpty(kapacitet))
                {
                    pronajdeni = _context.RAM.Where(k => k.Tip.Contains(tip)).ToList();
                }
                else if (string.IsNullOrEmpty(proizvoditel) && string.IsNullOrEmpty(tip) && !string.IsNullOrEmpty(kapacitet))
                {
                    pronajdeni = _context.RAM.Where(k => k.Kapacitet.Contains(kapacitet)).ToList();
                }
                else if (!string.IsNullOrEmpty(proizvoditel) && !string.IsNullOrEmpty(tip) && string.IsNullOrEmpty(kapacitet))
                {
                    pronajdeni = _context.RAM.Where(k => k.Proizvoditel.Contains(proizvoditel) && k.Tip.Contains(tip)).ToList();
                }
                else if (!string.IsNullOrEmpty(proizvoditel) && string.IsNullOrEmpty(tip) && !string.IsNullOrEmpty(kapacitet))
                {
                    pronajdeni = _context.RAM.Where(k => k.Proizvoditel.Contains(proizvoditel) && k.Kapacitet.Contains(kapacitet)).ToList();
                }
                else if (string.IsNullOrEmpty(proizvoditel) && !string.IsNullOrEmpty(tip) && !string.IsNullOrEmpty(kapacitet))
                {
                    pronajdeni = _context.RAM.Where(k => k.Tip.Contains(tip) && k.Kapacitet.Contains(kapacitet)).ToList();
                }
                else
                {
                    pronajdeni = _context.RAM.Where(k => k.Proizvoditel.Contains(proizvoditel) && k.Kapacitet.Contains(kapacitet) && k.Tip.Contains(tip)).ToList();
                }
                viewmodel.RAMs = pronajdeni;
                viewmodel.brojRAM = pronajdeni.Count();
            }
            else
            {
                viewmodel.RAMs = rams;
                viewmodel.brojRAM = rams.Count();
            }
            return View(viewmodel);
        }


        // GET: RAMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rAM = await _context.RAM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rAM == null)
            {
                return NotFound();
            }

            return View(rAM);
        }

        // GET: RAMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Proizvoditel,Model,Tip,Kapacitet,Speed,DetailsUrl,SlikaUrl,Cena")] RAM rAM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rAM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rAM);
        }

        // GET: RAMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rAM = await _context.RAM.FindAsync(id);
            if (rAM == null)
            {
                return NotFound();
            }
            return View(rAM);
        }

        // POST: RAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Proizvoditel,Model,Tip,Kapacitet,Speed,DetailsUrl,SlikaUrl,Cena")] RAM rAM)
        {
            if (id != rAM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rAM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RAMExists(rAM.Id))
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
            return View(rAM);
        }

        // GET: RAMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rAM = await _context.RAM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rAM == null)
            {
                return NotFound();
            }

            return View(rAM);
        }

        // POST: RAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rAM = await _context.RAM.FindAsync(id);
            if (rAM != null)
            {
                _context.RAM.Remove(rAM);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RAMExists(int id)
        {
            return _context.RAM.Any(e => e.Id == id);
        }
    }
}
