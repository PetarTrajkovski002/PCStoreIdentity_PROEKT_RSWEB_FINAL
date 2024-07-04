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
    public class KulersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KulersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kulers
        public async Task<IActionResult> Index(string model, string tdp)
        {
            var viewmodel = new FilterCooler();
            var kuleri = _context.Kuler.ToList();
            var pronajdeni = new List<Kuler>();

            if (!string.IsNullOrEmpty(model) || !string.IsNullOrEmpty(tdp))
            {
                if (!string.IsNullOrEmpty(model) && string.IsNullOrEmpty(tdp))
                {
                    pronajdeni = _context.Kuler.Where(k => k.Model.Contains(model)).ToList();
                }
                else if (string.IsNullOrEmpty(model) && !string.IsNullOrEmpty(tdp))
                {
                    int watts = Int32.Parse(tdp);

                    pronajdeni = _context.Kuler.Where(k => k.TDP == watts).ToList();
                }
                else
                {
                    int watts = Int32.Parse(tdp);
                    pronajdeni = _context.Kuler.Where(k => k.Model.Contains(model) && k.TDP == watts).ToList();
                }
                viewmodel.Coolers = pronajdeni;
                viewmodel.brojCoolers = pronajdeni.Count();
            }
            else
            {
                viewmodel.Coolers = kuleri;
                viewmodel.brojCoolers = kuleri.Count();
            }
            return View(viewmodel);
        }

        // GET: Kulers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kuler = await _context.Kuler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kuler == null)
            {
                return NotFound();
            }

            return View(kuler);
        }

        // GET: Kulers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kulers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,TDP,DetailsUrl,SlikaUrl,Cena")] Kuler kuler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kuler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kuler);
        }

        // GET: Kulers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kuler = await _context.Kuler.FindAsync(id);
            if (kuler == null)
            {
                return NotFound();
            }
            return View(kuler);
        }

        // POST: Kulers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,TDP,DetailsUrl,SlikaUrl,Cena")] Kuler kuler)
        {
            if (id != kuler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kuler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KulerExists(kuler.Id))
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
            return View(kuler);
        }

        // GET: Kulers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kuler = await _context.Kuler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kuler == null)
            {
                return NotFound();
            }

            return View(kuler);
        }

        // POST: Kulers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kuler = await _context.Kuler.FindAsync(id);
            if (kuler != null)
            {
                _context.Kuler.Remove(kuler);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KulerExists(int id)
        {
            return _context.Kuler.Any(e => e.Id == id);
        }
    }
}
