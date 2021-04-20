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
    public class TablaEpisodiosController : Controller
    {
        private readonly Contexto _context;

        public TablaEpisodiosController(Contexto context)
        {
            _context = context;
        }

        // GET: TablaEpisodios
        public async Task<IActionResult> Index()
        {
            return View(await _context.TablaEpisodios.ToListAsync());
        }

        // GET: TablaEpisodios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaEpisodios = await _context.TablaEpisodios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaEpisodios == null)
            {
                return NotFound();
            }

            return View(tablaEpisodios);
        }

        // GET: TablaEpisodios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TablaEpisodios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PacienteId,FechaInicio,FechaFinal,Motivo,Causa,Medicación")] TablaEpisodios tablaEpisodios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablaEpisodios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablaEpisodios);
        }

        // GET: TablaEpisodios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaEpisodios = await _context.TablaEpisodios.FindAsync(id);
            if (tablaEpisodios == null)
            {
                return NotFound();
            }
            return View(tablaEpisodios);
        }

        // POST: TablaEpisodios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PacienteId,FechaInicio,FechaFinal,Motivo,Causa,Medicación")] TablaEpisodios tablaEpisodios)
        {
            if (id != tablaEpisodios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaEpisodios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaEpisodiosExists(tablaEpisodios.Id))
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
            return View(tablaEpisodios);
        }

        // GET: TablaEpisodios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaEpisodios = await _context.TablaEpisodios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaEpisodios == null)
            {
                return NotFound();
            }

            return View(tablaEpisodios);
        }

        // POST: TablaEpisodios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablaEpisodios = await _context.TablaEpisodios.FindAsync(id);
            _context.TablaEpisodios.Remove(tablaEpisodios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaEpisodiosExists(int id)
        {
            return _context.TablaEpisodios.Any(e => e.Id == id);
        }
    }
}
