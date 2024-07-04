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
    public class NapojuvanjesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NapojuvanjesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Napojuvanjes
        public async Task<IActionResult> Index(string model, string power)
        {
            var viewmodel = new FilterPSU();
            var psus = _context.Napojuvanje.ToList();
            var pronajdeni = new List<Napojuvanje>();

            if (!string.IsNullOrEmpty(model) || !string.IsNullOrEmpty(power))
            {
                if (!string.IsNullOrEmpty(model) && string.IsNullOrEmpty(power))
                {
                    pronajdeni = _context.Napojuvanje.Where(k => k.Model.Contains(model)).ToList();
                }
                else if (string.IsNullOrEmpty(model) && !string.IsNullOrEmpty(power))
                {

                    int watts = Int32.Parse(power);
                    pronajdeni = _context.Napojuvanje.Where(k => k.Power == watts).ToList();
                }
                else
                {
                    int watts = Int32.Parse(power);
                    pronajdeni = _context.Napojuvanje.Where(k => k.Model.Contains(model) && k.Power == watts).ToList();
                }
                viewmodel.Napojuvanja = pronajdeni;
                viewmodel.brojPSU = pronajdeni.Count();
            }
            else
            {
                viewmodel.Napojuvanja = psus;
                viewmodel.brojPSU = psus.Count();
            }
            return View(viewmodel);
        }

        // GET: Napojuvanjes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var napojuvanje = await _context.Napojuvanje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (napojuvanje == null)
            {
                return NotFound();
            }

            return View(napojuvanje);
        }

        // GET: Napojuvanjes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Napojuvanjes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,Power,Rating,SlikaUrl,DetailsUrl,Cena")] Napojuvanje napojuvanje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(napojuvanje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(napojuvanje);
        }

        // GET: Napojuvanjes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var napojuvanje = await _context.Napojuvanje.FindAsync(id);
            if (napojuvanje == null)
            {
                return NotFound();
            }
            return View(napojuvanje);
        }

        // POST: Napojuvanjes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,Power,Rating,SlikaUrl,DetailsUrl,Cena")] Napojuvanje napojuvanje)
        {
            if (id != napojuvanje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(napojuvanje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NapojuvanjeExists(napojuvanje.Id))
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
            return View(napojuvanje);
        }

        // GET: Napojuvanjes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var napojuvanje = await _context.Napojuvanje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (napojuvanje == null)
            {
                return NotFound();
            }

            return View(napojuvanje);
        }

        // POST: Napojuvanjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var napojuvanje = await _context.Napojuvanje.FindAsync(id);
            if (napojuvanje != null)
            {
                _context.Napojuvanje.Remove(napojuvanje);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NapojuvanjeExists(int id)
        {
            return _context.Napojuvanje.Any(e => e.Id == id);
        }
    }
}
