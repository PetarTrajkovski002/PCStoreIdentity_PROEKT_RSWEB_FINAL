using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PCStoreIdentity.ViewModels;
using PCStoreIdentity.Data;
using PCStoreIdentity.Models;

namespace PCStoreIdentity.Controllers
{
    public class DisksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DisksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Disks
        public async Task<IActionResult> Index(string model, string kapacitet, string tip)
        {

            var viewmodel = new FilterDisk();
            var diskovi = _context.Disk.ToList();
            var pronajdeni = new List<Disk>();



            if (!string.IsNullOrEmpty(model) || !string.IsNullOrEmpty(kapacitet) || !string.IsNullOrEmpty(tip))
            {
                if (!string.IsNullOrEmpty(model) && string.IsNullOrEmpty(kapacitet) && string.IsNullOrEmpty(tip))
                {
                    pronajdeni = _context.Disk.Where(k => k.Model.Contains(model)).ToList();
                }
                else if (string.IsNullOrEmpty(model) && !string.IsNullOrEmpty(kapacitet) && string.IsNullOrEmpty(tip))
                {
                    int kp = Int32.Parse(kapacitet);

                    pronajdeni = _context.Disk.Where(k => k.Kapacitet == kp).ToList();
                }
                else if (string.IsNullOrEmpty(model) && string.IsNullOrEmpty(kapacitet) && !string.IsNullOrEmpty(tip))
                {
                    pronajdeni = _context.Disk.Where(k => k.Tip.Contains(tip)).ToList();
                }
                else if (!string.IsNullOrEmpty(model) && !string.IsNullOrEmpty(kapacitet) && string.IsNullOrEmpty(tip))
                {
                    int kp = Int32.Parse(kapacitet);
                    pronajdeni = _context.Disk.Where(k => k.Model.Contains(model) && k.Kapacitet == kp).ToList();
                }
                else if (!string.IsNullOrEmpty(model) && string.IsNullOrEmpty(kapacitet) && !string.IsNullOrEmpty(tip))
                {
                    pronajdeni = _context.Disk.Where(k => k.Model.Contains(model) && k.Tip.Contains(tip)).ToList();
                }
                else if (string.IsNullOrEmpty(model) && !string.IsNullOrEmpty(kapacitet) && !string.IsNullOrEmpty(tip))
                {
                    int kp = Int32.Parse(kapacitet);
                    pronajdeni = _context.Disk.Where(k => k.Kapacitet == kp && k.Tip.Contains(tip)).ToList();
                }
                else
                {
                    int kp = Int32.Parse(kapacitet);
                    pronajdeni = _context.Disk.Where(k => k.Model.Contains(model) && k.Kapacitet == kp && k.Tip.Contains(tip)).ToList();
                }
                viewmodel.Diskovi = pronajdeni;
                viewmodel.brojDisk = pronajdeni.Count();
            }
            else
            {
                viewmodel.Diskovi = diskovi;
                viewmodel.brojDisk = diskovi.Count();
            }
            return View(viewmodel);
        }

        // GET: Disks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disk = await _context.Disk
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disk == null)
            {
                return NotFound();
            }

            return View(disk);
        }

        // GET: Disks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Disks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,Kapacitet,Tip,SlikaUrl,DetailsUrl,Cena")] Disk disk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disk);
        }

        // GET: Disks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disk = await _context.Disk.FindAsync(id);
            if (disk == null)
            {
                return NotFound();
            }
            return View(disk);
        }

        // POST: Disks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,Kapacitet,Tip,SlikaUrl,DetailsUrl,Cena")] Disk disk)
        {
            if (id != disk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiskExists(disk.Id))
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
            return View(disk);
        }

        // GET: Disks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disk = await _context.Disk
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disk == null)
            {
                return NotFound();
            }

            return View(disk);
        }

        // POST: Disks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disk = await _context.Disk.FindAsync(id);
            if (disk != null)
            {
                _context.Disk.Remove(disk);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiskExists(int id)
        {
            return _context.Disk.Any(e => e.Id == id);
        }
    }
}
