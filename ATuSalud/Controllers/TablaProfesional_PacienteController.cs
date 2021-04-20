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
    public class TablaProfesional_PacienteController : Controller
    {
        private readonly Contexto _context;

        public TablaProfesional_PacienteController(Contexto context)
        {
            _context = context;
        }

        // GET: TablaProfesional_Paciente
        public async Task<IActionResult> Index()
        {
            return View(await _context.TablaProfesional_Paciente.ToListAsync());
        }

        // GET: TablaProfesional_Paciente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaProfesional_Paciente = await _context.TablaProfesional_Paciente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaProfesional_Paciente == null)
            {
                return NotFound();
            }

            return View(tablaProfesional_Paciente);
        }

        // GET: TablaProfesional_Paciente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TablaProfesional_Paciente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProfesionalId,PacienteId")] TablaProfesional_Paciente tablaProfesional_Paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablaProfesional_Paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablaProfesional_Paciente);
        }

        // GET: TablaProfesional_Paciente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaProfesional_Paciente = await _context.TablaProfesional_Paciente.FindAsync(id);
            if (tablaProfesional_Paciente == null)
            {
                return NotFound();
            }
            return View(tablaProfesional_Paciente);
        }

        // POST: TablaProfesional_Paciente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfesionalId,PacienteId")] TablaProfesional_Paciente tablaProfesional_Paciente)
        {
            if (id != tablaProfesional_Paciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaProfesional_Paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaProfesional_PacienteExists(tablaProfesional_Paciente.Id))
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
            return View(tablaProfesional_Paciente);
        }

        // GET: TablaProfesional_Paciente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaProfesional_Paciente = await _context.TablaProfesional_Paciente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaProfesional_Paciente == null)
            {
                return NotFound();
            }

            return View(tablaProfesional_Paciente);
        }

        // POST: TablaProfesional_Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablaProfesional_Paciente = await _context.TablaProfesional_Paciente.FindAsync(id);
            _context.TablaProfesional_Paciente.Remove(tablaProfesional_Paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaProfesional_PacienteExists(int id)
        {
            return _context.TablaProfesional_Paciente.Any(e => e.Id == id);
        }
    }
}
