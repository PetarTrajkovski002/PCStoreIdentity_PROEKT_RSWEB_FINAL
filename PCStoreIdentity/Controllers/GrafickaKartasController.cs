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
    public class GrafickaKartasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GrafickaKartasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GrafickaKartas
        public async Task<IActionResult> Index(string proizvoditel, string model, string vram)
        {
            var viewmodel = new FilterGPU();
            var gpus = _context.GrafickaKarta.ToList();
            var pronajdeni = new List<GrafickaKarta>();

            if (!string.IsNullOrEmpty(proizvoditel) || !string.IsNullOrEmpty(model) || !string.IsNullOrEmpty(vram))
            {
                if (!string.IsNullOrEmpty(proizvoditel) && string.IsNullOrEmpty(model) && string.IsNullOrEmpty(vram))
                {
                    pronajdeni = _context.GrafickaKarta.Where(k => k.Proizvoditel.Contains(proizvoditel)).ToList();
                }
                else if (string.IsNullOrEmpty(proizvoditel) && !string.IsNullOrEmpty(model) && string.IsNullOrEmpty(vram))
                {
                    pronajdeni = _context.GrafickaKarta.Where(k => k.Model.Contains(model)).ToList();
                }
                else if (string.IsNullOrEmpty(proizvoditel) && string.IsNullOrEmpty(model) && !string.IsNullOrEmpty(vram))
                {
                    pronajdeni = _context.GrafickaKarta.Where(k => k.VRAM.Contains(vram)).ToList();
                }
                else if (!string.IsNullOrEmpty(proizvoditel) && !string.IsNullOrEmpty(model) && string.IsNullOrEmpty(vram))
                {
                    pronajdeni = _context.GrafickaKarta.Where(k => k.Proizvoditel.Contains(proizvoditel) && k.Model.Contains(model)).ToList();
                }
                else if (!string.IsNullOrEmpty(proizvoditel) && string.IsNullOrEmpty(model) && !string.IsNullOrEmpty(vram))
                {
                    pronajdeni = _context.GrafickaKarta.Where(k => k.Proizvoditel.Contains(proizvoditel) && k.TipMemorija.Contains(vram)).ToList();
                }
                else if (string.IsNullOrEmpty(proizvoditel) && !string.IsNullOrEmpty(model) && !string.IsNullOrEmpty(vram))
                {
                    pronajdeni = _context.GrafickaKarta.Where(k => k.Model.Contains(model) && k.TipMemorija.Contains(vram)).ToList();
                }
                else
                {
                    pronajdeni = _context.GrafickaKarta.Where(k => k.Proizvoditel.Contains(proizvoditel) && k.Model.Contains(model) && k.TipMemorija.Contains(vram)).ToList();
                }
                viewmodel.GPUs = pronajdeni;
                viewmodel.brojGPU = pronajdeni.Count();
            }
            else
            {
                viewmodel.GPUs = gpus;
                viewmodel.brojGPU = gpus.Count();
            }
            return View(viewmodel);
        }

        // GET: GrafickaKartas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grafickaKarta = await _context.GrafickaKarta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grafickaKarta == null)
            {
                return NotFound();
            }

            return View(grafickaKarta);
        }

        // GET: GrafickaKartas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GrafickaKartas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Proizvoditel,Model,TipMemorija,VRAM,CoreClock,MemoryClock,Power,SlikaUrl,DetailsUrl,Cena")] GrafickaKarta grafickaKarta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grafickaKarta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grafickaKarta);
        }

        // GET: GrafickaKartas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grafickaKarta = await _context.GrafickaKarta.FindAsync(id);
            if (grafickaKarta == null)
            {
                return NotFound();
            }
            return View(grafickaKarta);
        }

        // POST: GrafickaKartas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Proizvoditel,Model,TipMemorija,VRAM,CoreClock,MemoryClock,Power,SlikaUrl,DetailsUrl,Cena")] GrafickaKarta grafickaKarta)
        {
            if (id != grafickaKarta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grafickaKarta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrafickaKartaExists(grafickaKarta.Id))
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
            return View(grafickaKarta);
        }

        // GET: GrafickaKartas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grafickaKarta = await _context.GrafickaKarta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grafickaKarta == null)
            {
                return NotFound();
            }

            return View(grafickaKarta);
        }

        // POST: GrafickaKartas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grafickaKarta = await _context.GrafickaKarta.FindAsync(id);
            if (grafickaKarta != null)
            {
                _context.GrafickaKarta.Remove(grafickaKarta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrafickaKartaExists(int id)
        {
            return _context.GrafickaKarta.Any(e => e.Id == id);
        }
    }
}
