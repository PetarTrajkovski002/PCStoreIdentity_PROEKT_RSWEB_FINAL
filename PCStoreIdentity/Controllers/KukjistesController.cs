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
    public class KukjistesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KukjistesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kukjistes
        public async Task<IActionResult> Index(string model, string ff)
        {
            var viewmodel = new FilterCases();
            var kukjista = _context.Kukjiste.ToList();
            var pronajdeni = new List<Kukjiste>();

            if (!string.IsNullOrEmpty(model) || !string.IsNullOrEmpty(ff))
            {
                if (!string.IsNullOrEmpty(model) && string.IsNullOrEmpty(ff))
                {
                    pronajdeni = _context.Kukjiste.Where(k => k.Model.Contains(model)).ToList();
                }
                else if (string.IsNullOrEmpty(model) && !string.IsNullOrEmpty(ff))
                {
                    pronajdeni = _context.Kukjiste.Where(k => k.FormFactor.Contains(ff)).ToList();
                }
                else
                {
                    pronajdeni = _context.Kukjiste.Where(k => k.Model.Contains(model) && k.FormFactor.Contains(ff)).ToList();
                }
                viewmodel.Cases = pronajdeni;
                viewmodel.brojCases = pronajdeni.Count();
            }
            else
            {
                viewmodel.Cases = kukjista;
                viewmodel.brojCases = kukjista.Count();
            }
            return View(viewmodel);
        }
    

        // GET: Kukjistes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kukjiste = await _context.Kukjiste
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kukjiste == null)
            {
                return NotFound();
            }

            return View(kukjiste);
        }

        // GET: Kukjistes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kukjistes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,FormFactor,SlikaUrl,DetailsUrl,Cena")] Kukjiste kukjiste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kukjiste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kukjiste);
        }

        // GET: Kukjistes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kukjiste = await _context.Kukjiste.FindAsync(id);
            if (kukjiste == null)
            {
                return NotFound();
            }
            return View(kukjiste);
        }

        // POST: Kukjistes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,FormFactor,SlikaUrl,DetailsUrl,Cena")] Kukjiste kukjiste)
        {
            if (id != kukjiste.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kukjiste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KukjisteExists(kukjiste.Id))
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
            return View(kukjiste);
        }

        // GET: Kukjistes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kukjiste = await _context.Kukjiste
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kukjiste == null)
            {
                return NotFound();
            }

            return View(kukjiste);
        }

        // POST: Kukjistes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kukjiste = await _context.Kukjiste.FindAsync(id);
            if (kukjiste != null)
            {
                _context.Kukjiste.Remove(kukjiste);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KukjisteExists(int id)
        {
            return _context.Kukjiste.Any(e => e.Id == id);
        }
    }
}
