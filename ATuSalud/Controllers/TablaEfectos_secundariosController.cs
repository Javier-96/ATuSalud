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
    public class TablaEfectos_secundariosController : Controller
    {
        private readonly Contexto _context;

        public TablaEfectos_secundariosController(Contexto context)
        {
            _context = context;
        }

        // GET: TablaEfectos_secundarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.TablaEfectosSecundarios.ToListAsync());
        }

        // GET: TablaEfectos_secundarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaEfectos_secundarios = await _context.TablaEfectosSecundarios
                .FirstOrDefaultAsync(m => m.id == id);
            if (tablaEfectos_secundarios == null)
            {
                return NotFound();
            }

            return View(tablaEfectos_secundarios);
        }

        // GET: TablaEfectos_secundarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TablaEfectos_secundarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre_efecto,severidad")] TablaEfectos_secundarios tablaEfectos_secundarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablaEfectos_secundarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablaEfectos_secundarios);
        }

        // GET: TablaEfectos_secundarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaEfectos_secundarios = await _context.TablaEfectosSecundarios.FindAsync(id);
            if (tablaEfectos_secundarios == null)
            {
                return NotFound();
            }
            return View(tablaEfectos_secundarios);
        }

        // POST: TablaEfectos_secundarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre_efecto,severidad")] TablaEfectos_secundarios tablaEfectos_secundarios)
        {
            if (id != tablaEfectos_secundarios.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaEfectos_secundarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaEfectos_secundariosExists(tablaEfectos_secundarios.id))
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
            return View(tablaEfectos_secundarios);
        }

        // GET: TablaEfectos_secundarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaEfectos_secundarios = await _context.TablaEfectosSecundarios
                .FirstOrDefaultAsync(m => m.id == id);
            if (tablaEfectos_secundarios == null)
            {
                return NotFound();
            }

            return View(tablaEfectos_secundarios);
        }

        // POST: TablaEfectos_secundarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablaEfectos_secundarios = await _context.TablaEfectosSecundarios.FindAsync(id);
            _context.TablaEfectosSecundarios.Remove(tablaEfectos_secundarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaEfectos_secundariosExists(int id)
        {
            return _context.TablaEfectosSecundarios.Any(e => e.id == id);
        }
    }
}
