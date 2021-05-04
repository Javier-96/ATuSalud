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
    public class TablaRecetasController : Controller
    {
        private readonly Contexto _context;

        public TablaRecetasController(Contexto context)
        {
            _context = context;
        }

        // GET: TablaRecetas
        public async Task<IActionResult> Index(int? id)
        {
            return View(await _context.TablaRecetas.Include(x=>x.Paciente).Include(x => x.Episodio).Include(x=>x.Medicamento).ToListAsync());
            
        }

        // GET: TablaRecetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaRecetas = await _context.TablaRecetas.Include(x=>x.Paciente).Include(x=>x.Medicamento).Include(x=>x.Episodio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaRecetas == null)
            {
                return NotFound();
            }

            return View(tablaRecetas);
        }

        // GET: TablaRecetas/Create
        public IActionResult Create()
        {
            ViewData["EpisodioID"] = new SelectList(_context.TablaEpisodios, "Id", "Nombre");
            ViewData["PacienteID"] = new SelectList(_context.TablaPaciente, "Id", "Nombre");
            ViewData["MedicamentoID"] = new SelectList(_context.TablaMedicamentos, "Id", "Nombre_medicamento");

            return View();
        }

        // POST: TablaRecetas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TablaRecetas tablaRecetas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablaRecetas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablaRecetas);
        }

        // GET: TablaRecetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaRecetas = await _context.TablaRecetas.FindAsync(id);
            if (tablaRecetas == null)
            {
                return NotFound();
            }
            ViewData["PacienteID"] = new SelectList(_context.TablaPaciente, "Id", "Nombre", tablaRecetas.PacienteID);
            ViewData["MedicamentoID"] = new SelectList(_context.TablaMedicamentos, "Id", "Nombre_medicamento", tablaRecetas.MedicamentoID);
            ViewData["EpisodioID"] = new SelectList(_context.TablaEpisodios, "Id", "Nombre",tablaRecetas.EpisodioID);
            return View(tablaRecetas);
        }

        // POST: TablaRecetas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TablaRecetas tablaRecetas)
        {
            if (id != tablaRecetas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaRecetas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaRecetasExists(tablaRecetas.Id))
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
            return View(tablaRecetas);
        }

        // GET: TablaRecetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaRecetas = await _context.TablaRecetas.Include(x => x.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaRecetas == null)
            {
                return NotFound();
            }

            return View(tablaRecetas);
        }

        // POST: TablaRecetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablaRecetas = await _context.TablaRecetas.FindAsync(id);
            _context.TablaRecetas.Remove(tablaRecetas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaRecetasExists(int id)
        {
            return _context.TablaRecetas.Any(e => e.Id == id);
        }
    }
}
