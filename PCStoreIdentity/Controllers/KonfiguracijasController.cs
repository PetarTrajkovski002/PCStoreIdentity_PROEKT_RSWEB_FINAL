using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PCStoreIdentity.Data;
using PCStoreIdentity.Models;
using PCStoreIdentity.ViewModels;

namespace PCStoreIdentity.Controllers
{
    public class KonfiguracijasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KonfiguracijasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Konfiguracijas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Konfiguracija.Include(k => k.CPU).Include(k => k.Case).Include(k => k.Cooler).Include(k => k.GPU).Include(k => k.Korisnik).Include(k => k.MB).Include(k => k.Memorija).Include(k => k.PSU).Include(k => k.SSD);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Konfiguracijas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konfiguracija = await _context.Konfiguracija
                .Include(k => k.CPU)
                .Include(k => k.Case)
                .Include(k => k.Cooler)
                .Include(k => k.GPU)
                .Include(k => k.Korisnik)
                .Include(k => k.MB)
                .Include(k => k.Memorija)
                .Include(k => k.PSU)
                .Include(k => k.SSD)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (konfiguracija == null)
            {
                return NotFound();
            }

            var cpu = _context.Procesor.Where(k => k.Id == konfiguracija.CPUId).ToList()[0];
            var mb = _context.MaticnaPloca.Where(k => k.Id == konfiguracija.MBId).ToList()[0];
            var ram = _context.RAM.Where(k => k.Id == konfiguracija.RAMId).ToList()[0];
            var gpu = _context.GrafickaKarta.Where(k => k.Id == konfiguracija.GPUId).ToList()[0];
            var disk = _context.Disk.Where(k => k.Id == konfiguracija.DiskId).ToList()[0];
            var box = _context.Kukjiste.Where(k => k.Id == konfiguracija.KukjisteId).ToList()[0];
            var cooler = _context.Kuler.Where(k => k.Id == konfiguracija.KulerId).ToList()[0];
            var psu = _context.Napojuvanje.Where(k => k.Id == konfiguracija.PSUId).ToList()[0];

            var korisnik = _context.Users.Where(k => k.Id == konfiguracija.KorisnikId).ToList()[0];

            var viewmodel = new VMKonfiguracija();
            viewmodel.konfiguracija = konfiguracija;
            viewmodel.CPU = cpu;
            viewmodel.MB = mb;
            viewmodel.RAM = ram;
            viewmodel.GPU = gpu;
            viewmodel.Disk = disk;
            viewmodel.Case = box;
            viewmodel.PSU = psu;
            viewmodel.Cooler = cooler;
            viewmodel.Korisnik = korisnik;
            
            return View(viewmodel);
        }

        // GET: Konfiguracijas/Create
        public IActionResult Create()
        {
            ViewData["CPUId"] = new SelectList(_context.Procesor, "Id", "Model");
            ViewData["KukjisteId"] = new SelectList(_context.Kukjiste, "Id", "Model");
            ViewData["KulerId"] = new SelectList(_context.Kuler, "Id", "Model");
            ViewData["GPUId"] = new SelectList(_context.GrafickaKarta, "Id", "Model");
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["MBId"] = new SelectList(_context.MaticnaPloca, "Id", "Model");
            ViewData["RAMId"] = new SelectList(_context.RAM, "Id", "Id");
            ViewData["PSUId"] = new SelectList(_context.Napojuvanje, "Id", "Model");
            ViewData["DiskId"] = new SelectList(_context.Disk, "Id", "Model");
            return View();
        }

        // POST: Konfiguracijas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KorisnikId,CPUId,MBId,RAMId,GPUId,DiskId,KukjisteId,PSUId,KulerId")] Konfiguracija konfiguracija)
        {
            try
            {
                _context.Add(konfiguracija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Please try again.");
                // Log the exception somewhere for troubleshooting
                Console.WriteLine(ex.Message);
                return View(konfiguracija); // Return the view with the model data to correct any issues
            }
            if (!ModelState.IsValid)
            {
                // Log or debug ModelState.Errors to identify issues
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return View(konfiguracija); // Return the view with the model data to correct any issues
            }

        }

        // GET: Konfiguracijas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konfiguracija = await _context.Konfiguracija.FindAsync(id);
            if (konfiguracija == null)
            {
                return NotFound();
            }
            ViewData["CPUId"] = new SelectList(_context.Procesor, "Id", "Model", konfiguracija.CPUId);
            ViewData["KukjisteId"] = new SelectList(_context.Kukjiste, "Id", "Model", konfiguracija.KukjisteId);
            ViewData["KulerId"] = new SelectList(_context.Kuler, "Id", "Model", konfiguracija.KulerId);
            ViewData["GPUId"] = new SelectList(_context.GrafickaKarta, "Id", "Model", konfiguracija.GPUId);
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id", konfiguracija.KorisnikId);
            ViewData["MBId"] = new SelectList(_context.MaticnaPloca, "Id", "Model", konfiguracija.MBId);
            ViewData["RAMId"] = new SelectList(_context.RAM, "Id", "Id", konfiguracija.RAMId);
            ViewData["PSUId"] = new SelectList(_context.Napojuvanje, "Id", "Model", konfiguracija.PSUId);
            ViewData["DiskId"] = new SelectList(_context.Disk, "Id", "Model", konfiguracija.DiskId);
            return View(konfiguracija);
        }

        // POST: Konfiguracijas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KorisnikId,CPUId,MBId,RAMId,GPUId,DiskId,KukjisteId,PSUId,KulerId")] Konfiguracija konfiguracija)
        {
            if (id != konfiguracija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(konfiguracija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KonfiguracijaExists(konfiguracija.Id))
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
            ViewData["CPUId"] = new SelectList(_context.Procesor, "Id", "Model", konfiguracija.CPUId);
            ViewData["KukjisteId"] = new SelectList(_context.Kukjiste, "Id", "Model", konfiguracija.KukjisteId);
            ViewData["KulerId"] = new SelectList(_context.Kuler, "Id", "Model", konfiguracija.KulerId);
            ViewData["GPUId"] = new SelectList(_context.GrafickaKarta, "Id", "Model", konfiguracija.GPUId);
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id", konfiguracija.KorisnikId);
            ViewData["MBId"] = new SelectList(_context.MaticnaPloca, "Id", "Model", konfiguracija.MBId);
            ViewData["RAMId"] = new SelectList(_context.RAM, "Id", "Id", konfiguracija.RAMId);
            ViewData["PSUId"] = new SelectList(_context.Napojuvanje, "Id", "Model", konfiguracija.PSUId);
            ViewData["DiskId"] = new SelectList(_context.Disk, "Id", "Model", konfiguracija.DiskId);
            return View(konfiguracija);
        }

        // GET: Konfiguracijas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konfiguracija = await _context.Konfiguracija
                .Include(k => k.CPU)
                .Include(k => k.Case)
                .Include(k => k.Cooler)
                .Include(k => k.GPU)
                .Include(k => k.Korisnik)
                .Include(k => k.MB)
                .Include(k => k.Memorija)
                .Include(k => k.PSU)
                .Include(k => k.SSD)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (konfiguracija == null)
            {
                return NotFound();
            }

            return View(konfiguracija);
        }

        // POST: Konfiguracijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var konfiguracija = await _context.Konfiguracija.FindAsync(id);
            if (konfiguracija != null)
            {
                _context.Konfiguracija.Remove(konfiguracija);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KonfiguracijaExists(int id)
        {
            return _context.Konfiguracija.Any(e => e.Id == id);
        }
    }
}
