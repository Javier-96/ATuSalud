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
    public class TablaMedicamentosController : Controller
    {
        private readonly Contexto _context;

        public TablaMedicamentosController(Contexto context)
        {
            _context = context;
        }

        // GET: TablaMedicamentos
        public async Task<IActionResult> Index()
        {
            return PartialView(await _context.TablaMedicamentos.Include(x=>x.EfectoSec).ToListAsync());
        }

        // GET: TablaMedicamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaMedicamentos = await _context.TablaMedicamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaMedicamentos == null)
            {
                return NotFound();
            }

            return View(tablaMedicamentos);
        }

        // GET: TablaMedicamentos/Create
        public IActionResult Create()
        {
            ViewData["EfectoID"] = new SelectList(_context.TablaEfectosSecundarios, "id", "nombre_efecto");

            return View();
        }

        // POST: TablaMedicamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( TablaMedicamentos tablaMedicamentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablaMedicamentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablaMedicamentos);
        }

        // GET: TablaMedicamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaMedicamentos = await _context.TablaMedicamentos.FindAsync(id);
            if (tablaMedicamentos == null)
            {
                return NotFound();
            }
            return View(tablaMedicamentos);
        }

        // POST: TablaMedicamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  TablaMedicamentos tablaMedicamentos)
        {
            if (id != tablaMedicamentos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaMedicamentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaMedicamentosExists(tablaMedicamentos.Id))
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
            return View(tablaMedicamentos);
        }

        // GET: TablaMedicamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaMedicamentos = await _context.TablaMedicamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaMedicamentos == null)
            {
                return NotFound();
            }

            return View(tablaMedicamentos);
        }

        // POST: TablaMedicamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablaMedicamentos = await _context.TablaMedicamentos.FindAsync(id);
            _context.TablaMedicamentos.Remove(tablaMedicamentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaMedicamentosExists(int id)
        {
            return _context.TablaMedicamentos.Any(e => e.Id == id);
        }
    }
}
