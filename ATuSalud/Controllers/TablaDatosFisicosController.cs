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
    public class TablaDatosFisicosController : Controller
    {
        private readonly Contexto _context;

        public TablaDatosFisicosController(Contexto context)
        {
            _context = context;
        }

        // GET: TablaDatosFisicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TablaDatosFisicos.ToListAsync());
        }

        // GET: TablaDatosFisicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaDatosFisicos = await _context.TablaDatosFisicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaDatosFisicos == null)
            {
                return NotFound();
            }

            return View(tablaDatosFisicos);
        }

        // GET: TablaDatosFisicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TablaDatosFisicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PacienteId,Nombre,Peso,Altura,Alergias,Grupo_sanguineo,Fumador,Drogas")] TablaDatosFisicos tablaDatosFisicos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablaDatosFisicos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablaDatosFisicos);
        }

        // GET: TablaDatosFisicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaDatosFisicos = await _context.TablaDatosFisicos.FindAsync(id);
            if (tablaDatosFisicos == null)
            {
                return NotFound();
            }
            return View(tablaDatosFisicos);
        }

        // POST: TablaDatosFisicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PacienteId,Nombre,Peso,Altura,Alergias,Grupo_sanguineo,Fumador,Drogas")] TablaDatosFisicos tablaDatosFisicos)
        {
            if (id != tablaDatosFisicos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaDatosFisicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaDatosFisicosExists(tablaDatosFisicos.Id))
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
            return View(tablaDatosFisicos);
        }

        // GET: TablaDatosFisicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaDatosFisicos = await _context.TablaDatosFisicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaDatosFisicos == null)
            {
                return NotFound();
            }

            return View(tablaDatosFisicos);
        }

        // POST: TablaDatosFisicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablaDatosFisicos = await _context.TablaDatosFisicos.FindAsync(id);
            _context.TablaDatosFisicos.Remove(tablaDatosFisicos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaDatosFisicosExists(int id)
        {
            return _context.TablaDatosFisicos.Any(e => e.Id == id);
        }
    }
}
