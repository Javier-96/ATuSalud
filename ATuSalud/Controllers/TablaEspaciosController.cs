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
    public class TablaEspaciosController : Controller
    {
        private readonly Contexto _context;

        public TablaEspaciosController(Contexto context)
        {
            _context = context;
        }

        // GET: TablaEspacios
        public async Task<IActionResult> Index(int? idPaciente)
        {
            var contexto = _context.TablaEspacios.Include(t => t.Reserva);
            return PartialView(await contexto.ToListAsync());
        }

        // GET: TablaEspacios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaEspacios = await _context.TablaEspacios
                .Include(t => t.Reserva)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaEspacios == null)
            {
                return NotFound();
            }

            return View(tablaEspacios);
        }

        // GET: TablaEspacios/Create
        public IActionResult Create()
        {
            ViewData["ReservaID"] = new SelectList(_context.TablaReservaEspacios, "Id", "Id");
            return View();
        }

        // POST: TablaEspacios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReservaID,EspacioGeneral,Mobiliario")] TablaEspacios tablaEspacios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablaEspacios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReservaID"] = new SelectList(_context.TablaReservaEspacios, "Id", "Id", tablaEspacios.ReservaID);
            return View(tablaEspacios);
        }

        // GET: TablaEspacios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaEspacios = await _context.TablaEspacios.FindAsync(id);
            if (tablaEspacios == null)
            {
                return NotFound();
            }
            ViewData["ReservaID"] = new SelectList(_context.TablaReservaEspacios, "Id", "Id", tablaEspacios.ReservaID);
            return View(tablaEspacios);
        }

        // POST: TablaEspacios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReservaID,EspacioGeneral,Mobiliario")] TablaEspacios tablaEspacios)
        {
            if (id != tablaEspacios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaEspacios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaEspaciosExists(tablaEspacios.Id))
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
            ViewData["ReservaID"] = new SelectList(_context.TablaReservaEspacios, "Id", "Id", tablaEspacios.ReservaID);
            return View(tablaEspacios);
        }

        // GET: TablaEspacios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaEspacios = await _context.TablaEspacios
                .Include(t => t.Reserva)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaEspacios == null)
            {
                return NotFound();
            }

            return View(tablaEspacios);
        }

        // POST: TablaEspacios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablaEspacios = await _context.TablaEspacios.FindAsync(id);
            _context.TablaEspacios.Remove(tablaEspacios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaEspaciosExists(int id)
        {
            return _context.TablaEspacios.Any(e => e.Id == id);
        }
    }
}
