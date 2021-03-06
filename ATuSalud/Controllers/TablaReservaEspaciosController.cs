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
    public class TablaReservaEspaciosController : Controller
    {
        private readonly Contexto _context;

        public TablaReservaEspaciosController(Contexto context)
        {
            _context = context;
        }

        // GET: TablaReservaEspacios1
        public async Task<IActionResult> Index()
        {
            return View(await _context.TablaReservaEspacios.Include("Profesional").ToListAsync());
           
        }

        // GET: TablaReservaEspacios1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaReservaEspacios = await _context.TablaReservaEspacios
                .Include(t => t.Profesional)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaReservaEspacios == null)
            {
                return NotFound();
            }

            return View(tablaReservaEspacios);
        }

        // GET: TablaReservaEspacios1/Create
        public IActionResult Create()
        {
            ViewData["ProfesionalId"] = new SelectList(_context.TablaProfesional, "id", "nombre");
            return View();
        }

        // POST: TablaReservaEspacios1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProfesionalId,Espacio,FechaInicio,FechaFin")] TablaReservaEspacios tablaReservaEspacios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablaReservaEspacios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfesionalId"] = new SelectList(_context.TablaProfesional, "id", "nombre", tablaReservaEspacios.ProfesionalId);
            return View(tablaReservaEspacios);
        }

        // GET: TablaReservaEspacios1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaReservaEspacios = await _context.TablaReservaEspacios.FindAsync(id);
            if (tablaReservaEspacios == null)
            {
                return NotFound();
            }
            ViewData["ProfesionalId"] = new SelectList(_context.TablaProfesional, "id", "nombre", tablaReservaEspacios.ProfesionalId);
            return View(tablaReservaEspacios);
        }

        // POST: TablaReservaEspacios1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfesionalId,Espacio,FechaInicio,FechaFin")] TablaReservaEspacios tablaReservaEspacios)
        {
            if (id != tablaReservaEspacios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaReservaEspacios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaReservaEspaciosExists(tablaReservaEspacios.Id))
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
            ViewData["ProfesionalId"] = new SelectList(_context.TablaProfesional, "id", "nombre", tablaReservaEspacios.ProfesionalId);
            return View(tablaReservaEspacios);
        }

        // GET: TablaReservaEspacios1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaReservaEspacios = await _context.TablaReservaEspacios
                .Include(t => t.Profesional)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaReservaEspacios == null)
            {
                return NotFound();
            }

            return View(tablaReservaEspacios);
        }

        // POST: TablaReservaEspacios1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablaReservaEspacios = await _context.TablaReservaEspacios.FindAsync(id);
            _context.TablaReservaEspacios.Remove(tablaReservaEspacios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaReservaEspaciosExists(int id)
        {
            return _context.TablaReservaEspacios.Any(e => e.Id == id);
        }
    }
}
