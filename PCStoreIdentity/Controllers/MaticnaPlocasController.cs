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
    public class MaticnaPlocasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaticnaPlocasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MaticnaPlocas
        public async Task<IActionResult> Index(string proizvoditel, string model, string tipmemorija)
        {
            var viewmodel = new FilterMotherboard();
            var mbs = _context.MaticnaPloca.ToList();
            var pronajdeni = new List<MaticnaPloca>();

            if (!string.IsNullOrEmpty(proizvoditel) || !string.IsNullOrEmpty(model) || !string.IsNullOrEmpty(tipmemorija))
            {
                if (!string.IsNullOrEmpty(proizvoditel) && string.IsNullOrEmpty(model) && string.IsNullOrEmpty(tipmemorija))
                {
                    pronajdeni = _context.MaticnaPloca.Where(k => k.Proizvoditel.Contains(proizvoditel)).ToList();
                }
                else if (string.IsNullOrEmpty(proizvoditel) && !string.IsNullOrEmpty(model) && string.IsNullOrEmpty(tipmemorija))
                {
                    pronajdeni = _context.MaticnaPloca.Where(k => k.Model.Contains(model)).ToList();
                }
                else if (string.IsNullOrEmpty(proizvoditel) && string.IsNullOrEmpty(model) && !string.IsNullOrEmpty(tipmemorija))
                {
                    pronajdeni = _context.MaticnaPloca.Where(k => k.TipMemorija.Contains(tipmemorija)).ToList();
                }
                else if (!string.IsNullOrEmpty(proizvoditel) && !string.IsNullOrEmpty(model) && string.IsNullOrEmpty(tipmemorija))
                {
                    pronajdeni = _context.MaticnaPloca.Where(k => k.Proizvoditel.Contains(proizvoditel) && k.Model.Contains(model)).ToList();
                }
                else if (!string.IsNullOrEmpty(proizvoditel) && string.IsNullOrEmpty(model) && !string.IsNullOrEmpty(tipmemorija))
                {
                    pronajdeni = _context.MaticnaPloca.Where(k => k.Proizvoditel.Contains(proizvoditel) && k.TipMemorija.Contains(tipmemorija)).ToList();
                }
                else if (string.IsNullOrEmpty(proizvoditel) && !string.IsNullOrEmpty(model) && !string.IsNullOrEmpty(tipmemorija))
                {
                    pronajdeni = _context.MaticnaPloca.Where(k => k.Model.Contains(model) && k.TipMemorija.Contains(tipmemorija)).ToList();
                }
                else
                {
                    pronajdeni = _context.MaticnaPloca.Where(k => k.Proizvoditel.Contains(proizvoditel) && k.Model.Contains(model) && k.TipMemorija.Contains(tipmemorija)).ToList();
                }
                viewmodel.Ploci = pronajdeni;
                viewmodel.brojPloci = pronajdeni.Count();
            }
            else
            {
                viewmodel.Ploci = mbs;
                viewmodel.brojPloci = mbs.Count();
            }
            return View(viewmodel);
        }

        // GET: MaticnaPlocas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maticnaPloca = await _context.MaticnaPloca
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maticnaPloca == null)
            {
                return NotFound();
            }

            return View(maticnaPloca);
        }

        // GET: MaticnaPlocas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaticnaPlocas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Proizvoditel,Model,TipMemorija,MaxRAMSpeed,CPUSocket,SlikaUrl,DetailsUrl,Cena")] MaticnaPloca maticnaPloca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maticnaPloca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maticnaPloca);
        }

        // GET: MaticnaPlocas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maticnaPloca = await _context.MaticnaPloca.FindAsync(id);
            if (maticnaPloca == null)
            {
                return NotFound();
            }
            return View(maticnaPloca);
        }

        // POST: MaticnaPlocas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Proizvoditel,Model,TipMemorija,MaxRAMSpeed,CPUSocket,SlikaUrl,DetailsUrl,Cena")] MaticnaPloca maticnaPloca)
        {
            if (id != maticnaPloca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maticnaPloca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaticnaPlocaExists(maticnaPloca.Id))
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
            return View(maticnaPloca);
        }

        // GET: MaticnaPlocas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maticnaPloca = await _context.MaticnaPloca
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maticnaPloca == null)
            {
                return NotFound();
            }

            return View(maticnaPloca);
        }

        // POST: MaticnaPlocas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maticnaPloca = await _context.MaticnaPloca.FindAsync(id);
            if (maticnaPloca != null)
            {
                _context.MaticnaPloca.Remove(maticnaPloca);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaticnaPlocaExists(int id)
        {
            return _context.MaticnaPloca.Any(e => e.Id == id);
        }
    }
}
