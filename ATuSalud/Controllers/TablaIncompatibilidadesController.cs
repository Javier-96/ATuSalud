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
    public class TablaIncompatibilidadesController : Controller
    {
        private readonly Contexto _context;

        public TablaIncompatibilidadesController(Contexto context)
        {
            _context = context;
        }

        // GET: TablaIncompatibilidades
        public async Task<IActionResult> Index()
        {
            var contexto = _context.TablaIncompatibilidades.Include(t => t.Medicamento).Include(t => t.MedicamentoIncompatible);
            return View(await contexto.ToListAsync());
        }

        // GET: TablaIncompatibilidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaIncompatibilidades = await _context.TablaIncompatibilidades
                .Include(t => t.Medicamento)
                .Include(t => t.MedicamentoIncompatible)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaIncompatibilidades == null)
            {
                return NotFound();
            }

            return View(tablaIncompatibilidades);
        }

        // GET: TablaIncompatibilidades/Create
        public IActionResult Create()
        {
            ViewData["MedicamentoID"] = new SelectList(_context.TablaMedicamentos, "Id", "Id");
            ViewData["MedicamentoIncompatibleID"] = new SelectList(_context.TablaMedicamentos, "Id", "Id");
            return View();
        }

        // POST: TablaIncompatibilidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MedicamentoID,MedicamentoIncompatibleID")] TablaIncompatibilidades tablaIncompatibilidades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablaIncompatibilidades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicamentoID"] = new SelectList(_context.TablaMedicamentos, "Id", "Id", tablaIncompatibilidades.MedicamentoID);
            ViewData["MedicamentoIncompatibleID"] = new SelectList(_context.TablaMedicamentos, "Id", "Id", tablaIncompatibilidades.MedicamentoIncompatibleID);
            return View(tablaIncompatibilidades);
        }

        // GET: TablaIncompatibilidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaIncompatibilidades = await _context.TablaIncompatibilidades.FindAsync(id);
            if (tablaIncompatibilidades == null)
            {
                return NotFound();
            }
            ViewData["MedicamentoID"] = new SelectList(_context.TablaMedicamentos, "Id", "Id", tablaIncompatibilidades.MedicamentoID);
            ViewData["MedicamentoIncompatibleID"] = new SelectList(_context.TablaMedicamentos, "Id", "Id", tablaIncompatibilidades.MedicamentoIncompatibleID);
            return View(tablaIncompatibilidades);
        }

        // POST: TablaIncompatibilidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MedicamentoID,MedicamentoIncompatibleID")] TablaIncompatibilidades tablaIncompatibilidades)
        {
            if (id != tablaIncompatibilidades.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaIncompatibilidades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaIncompatibilidadesExists(tablaIncompatibilidades.Id))
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
            ViewData["MedicamentoID"] = new SelectList(_context.TablaMedicamentos, "Id", "Id", tablaIncompatibilidades.MedicamentoID);
            ViewData["MedicamentoIncompatibleID"] = new SelectList(_context.TablaMedicamentos, "Id", "Id", tablaIncompatibilidades.MedicamentoIncompatibleID);
            return View(tablaIncompatibilidades);
        }

        // GET: TablaIncompatibilidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaIncompatibilidades = await _context.TablaIncompatibilidades
                .Include(t => t.Medicamento)
                .Include(t => t.MedicamentoIncompatible)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaIncompatibilidades == null)
            {
                return NotFound();
            }

            return View(tablaIncompatibilidades);
        }

        // POST: TablaIncompatibilidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablaIncompatibilidades = await _context.TablaIncompatibilidades.FindAsync(id);
            _context.TablaIncompatibilidades.Remove(tablaIncompatibilidades);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaIncompatibilidadesExists(int id)
        {
            return _context.TablaIncompatibilidades.Any(e => e.Id == id);
        }
    }
}
