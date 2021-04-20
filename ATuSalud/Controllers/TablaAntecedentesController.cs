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
    public class TablaAntecedentesController : Controller
    {
        private readonly Contexto _context;

        public TablaAntecedentesController(Contexto context)
        {
            _context = context;
        }

        // GET: TablaAntecedentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TablaAntecedentes.ToListAsync());
        }

        // GET: TablaAntecedentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaAntecedentes = await _context.TablaAntecedentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaAntecedentes == null)
            {
                return NotFound();
            }

            return View(tablaAntecedentes);
        }

        // GET: TablaAntecedentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TablaAntecedentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Paciente,Familiar,Enfermedad")] TablaAntecedentes tablaAntecedentes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablaAntecedentes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablaAntecedentes);
        }

        // GET: TablaAntecedentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaAntecedentes = await _context.TablaAntecedentes.FindAsync(id);
            if (tablaAntecedentes == null)
            {
                return NotFound();
            }
            return View(tablaAntecedentes);
        }

        // POST: TablaAntecedentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Paciente,Familiar,Enfermedad")] TablaAntecedentes tablaAntecedentes)
        {
            if (id != tablaAntecedentes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaAntecedentes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaAntecedentesExists(tablaAntecedentes.Id))
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
            return View(tablaAntecedentes);
        }

        // GET: TablaAntecedentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaAntecedentes = await _context.TablaAntecedentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaAntecedentes == null)
            {
                return NotFound();
            }

            return View(tablaAntecedentes);
        }

        // POST: TablaAntecedentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablaAntecedentes = await _context.TablaAntecedentes.FindAsync(id);
            _context.TablaAntecedentes.Remove(tablaAntecedentes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaAntecedentesExists(int id)
        {
            return _context.TablaAntecedentes.Any(e => e.Id == id);
        }
    }
}
