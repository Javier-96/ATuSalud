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
    public class TablaMedicamento_efectosController : Controller
    {
        private readonly Contexto _context;

        public TablaMedicamento_efectosController(Contexto context)
        {
            _context = context;
        }

        // GET: TablaMedicamento_efectos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.TablaMedicamentoEfectos.Include(t => t.Efecto).Include(t => t.Medicamento);
            return View(await contexto.ToListAsync());
        }

        // GET: TablaMedicamento_efectos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaMedicamento_efectos = await _context.TablaMedicamentoEfectos
                .Include(t => t.Efecto)
                .Include(t => t.Medicamento)
                .FirstOrDefaultAsync(m => m.id == id);
            if (tablaMedicamento_efectos == null)
            {
                return NotFound();
            }

            return View(tablaMedicamento_efectos);
        }

        // GET: TablaMedicamento_efectos/Create
        public IActionResult Create()
        {
            ViewData["EfectoId"] = new SelectList(_context.TablaEfectosSecundarios, "id", "id");
            ViewData["MedicamentoId"] = new SelectList(_context.TablaMedicamentos, "Id", "Id");
            return View();
        }

        // POST: TablaMedicamento_efectos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for hs
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,MedicamentoId,EfectoId")] TablaMedicamento_efectos tablaMedicamento_efectos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablaMedicamento_efectos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EfectoId"] = new SelectList(_context.TablaEfectosSecundarios, "id", "id", tablaMedicamento_efectos.EfectoId);
            ViewData["MedicamentoId"] = new SelectList(_context.TablaMedicamentos, "Id", "Id", tablaMedicamento_efectos.MedicamentoId);
            return View(tablaMedicamento_efectos);
        }

        // GET: TablaMedicamento_efectos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaMedicamento_efectos = await _context.TablaMedicamentoEfectos.FindAsync(id);
            if (tablaMedicamento_efectos == null)
            {
                return NotFound();
            }
            ViewData["EfectoId"] = new SelectList(_context.TablaEfectosSecundarios, "id", "id", tablaMedicamento_efectos.EfectoId);
            ViewData["MedicamentoId"] = new SelectList(_context.TablaMedicamentos, "Id", "Id", tablaMedicamento_efectos.MedicamentoId);
            return View(tablaMedicamento_efectos);
        }

        // POST: TablaMedicamento_efectos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("id,MedicamentoId,EfectoId")] TablaMedicamento_efectos tablaMedicamento_efectos)
        {
            if (id != tablaMedicamento_efectos.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaMedicamento_efectos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaMedicamento_efectosExists(tablaMedicamento_efectos.id))
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
            ViewData["EfectoId"] = new SelectList(_context.TablaEfectosSecundarios, "id", "id", tablaMedicamento_efectos.EfectoId);
            ViewData["MedicamentoId"] = new SelectList(_context.TablaMedicamentos, "Id", "Id", tablaMedicamento_efectos.MedicamentoId);
            return View(tablaMedicamento_efectos);
        }

        // GET: TablaMedicamento_efectos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaMedicamento_efectos = await _context.TablaMedicamentoEfectos
                .Include(t => t.Efecto)
                .Include(t => t.Medicamento)
                .FirstOrDefaultAsync(m => m.id == id);
            if (tablaMedicamento_efectos == null)
            {
                return NotFound();
            }

            return View(tablaMedicamento_efectos);
        }

        // POST: TablaMedicamento_efectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var tablaMedicamento_efectos = await _context.TablaMedicamentoEfectos.FindAsync(id);
            _context.TablaMedicamentoEfectos.Remove(tablaMedicamento_efectos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaMedicamento_efectosExists(int? id)
        {
            return _context.TablaMedicamentoEfectos.Any(e => e.id == id);
        }
    }
}
