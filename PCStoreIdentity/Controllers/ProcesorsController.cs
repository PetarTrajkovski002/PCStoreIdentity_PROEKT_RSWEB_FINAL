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
    public class ProcesorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProcesorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Procesors
        public async Task<IActionResult> Index(string proizvoditel, string model)
        {
            var viewmodel = new FilterCPU();
            var procesori = _context.Procesor.ToList();
            var pronajdeni = new List<Procesor>();

            if (!string.IsNullOrEmpty(proizvoditel) || !string.IsNullOrEmpty(model))
            {
                if (!string.IsNullOrEmpty(proizvoditel) && string.IsNullOrEmpty(model))
                {
                    pronajdeni = _context.Procesor.Where(k => k.Proizvoditel.Contains(proizvoditel)).ToList();
                }
                else if (string.IsNullOrEmpty(proizvoditel) && !string.IsNullOrEmpty(model))
                {
                    pronajdeni = _context.Procesor.Where(k => k.Model.Contains(model)).ToList();
                }
                else
                {
                    pronajdeni = _context.Procesor.Where(k => k.Proizvoditel.Contains(proizvoditel) && k.Model.Contains(model)).ToList();
                }
                viewmodel.Procesori = pronajdeni;
                viewmodel.brojCPU = pronajdeni.Count();
            }
            else
            {
                viewmodel.Procesori = procesori;
                viewmodel.brojCPU = procesori.Count();
            }
            return View(viewmodel);
        }

        // GET: Procesors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesor = await _context.Procesor
                .FirstOrDefaultAsync(m => m.Id == id);


            if (procesor == null)
            {
                return NotFound();
            }
            var modelploci = new CompatibleCPUMB();

            var query = _context.MaticnaProcesor.Where(k => k.ProcesorId == id).ToList();
            var resultat = new List<MaticnaPloca>();
            var sitematicni = _context.MaticnaPloca.ToList();

            foreach (var s in sitematicni)
            {
                foreach (var q in query)
                {
                    if (s.Id == q.MaticnaId)
                    {
                        resultat.Add(s);
                    }
                }
            }
            modelploci.CPU = procesor;
            modelploci.Ploci = resultat;
            return View(modelploci);
        }

        // GET: Procesors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Procesors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Proizvoditel,Model,Generation,Cores,Threads,Speed,Power,DetailsUrl,SlikaUrl,Cena")] Procesor procesor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procesor);
        }

        // GET: Procesors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesor = await _context.Procesor.FindAsync(id);
            if (procesor == null)
            {
                return NotFound();
            }
            return View(procesor);
        }

        // POST: Procesors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Proizvoditel,Model,Generation,Cores,Threads,Speed,Power,DetailsUrl,SlikaUrl,Cena")] Procesor procesor)
        {
            if (id != procesor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcesorExists(procesor.Id))
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
            return View(procesor);
        }

        // GET: Procesors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesor = await _context.Procesor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procesor == null)
            {
                return NotFound();
            }

            return View(procesor);
        }

        // POST: Procesors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procesor = await _context.Procesor.FindAsync(id);
            if (procesor != null)
            {
                _context.Procesor.Remove(procesor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcesorExists(int id)
        {
            return _context.Procesor.Any(e => e.Id == id);
        }
    }
}
