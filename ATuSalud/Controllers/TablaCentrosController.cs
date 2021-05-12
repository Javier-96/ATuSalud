using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ATuSalud.Models;
using ConexionSQL.Models;

namespace ATuSalud.Controllers
{
    public class TablaCentrosController : Controller
    {
        private readonly Contexto _context;

        public TablaCentrosController(Contexto context)
        {
            _context = context;
        }

        // GET: TablaCentros
        public async Task<IActionResult> Index()
        {
            return View(await _context.TablaCentros.ToListAsync());
        }

        // GET: TablaCentros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaCentros = await _context.TablaCentros
                .FirstOrDefaultAsync(m => m.id == id);
            if (tablaCentros == null)
            {
                return NotFound();
            }

            return View(tablaCentros);
        }

        // GET: TablaCentros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TablaCentros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre,direccion")] TablaCentros tablaCentros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablaCentros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablaCentros);
        }

        // GET: TablaCentros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaCentros = await _context.TablaCentros.FindAsync(id);
            if (tablaCentros == null)
            {
                return NotFound();
            }
            return View(tablaCentros);
        }

        // POST: TablaCentros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,direccion")] TablaCentros tablaCentros)
        {
            if (id != tablaCentros.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaCentros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaCentrosExists(tablaCentros.id))
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
            return View(tablaCentros);
        }

        // GET: TablaCentros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaCentros = await _context.TablaCentros
                .FirstOrDefaultAsync(m => m.id == id);
            if (tablaCentros == null)
            {
                return NotFound();
            }

            return View(tablaCentros);
        }

        // POST: TablaCentros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablaCentros = await _context.TablaCentros.FindAsync(id);
            _context.TablaCentros.Remove(tablaCentros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaCentrosExists(int id)
        {
            return _context.TablaCentros.Any(e => e.id == id);
        }
    }
}
