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
    public class TablaCitasPacientesController : Controller
    {
        private readonly Contexto _context;

        public TablaCitasPacientesController(Contexto context)
        {
            _context = context;
        }

        // GET: TablaCitasPacientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TablaCitasPaciente.Include(x => x.TablaPaciente).Include(x => x.TablaProfesional).ToListAsync());
        }

        // GET: TablaCitasPacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaCitasPaciente = await _context.TablaCitasPaciente.Include(x=>x.TablaPaciente).Include(x=>x.TablaProfesional)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaCitasPaciente == null)
            {
                return NotFound();
            }

            return View(tablaCitasPaciente);
        }

        // GET: TablaCitasPacientes/Create
        public IActionResult Create()
        {
            ViewData["Paciente"] = new SelectList(_context.TablaPaciente, "Id", "Nombre");
            ViewData["Profesional"] = new SelectList(_context.TablaProfesional, "id", "nombre");
            return View();
        }

        // POST: TablaCitasPacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TablaPacienteId,TablaProfesionalId,Fecha_atencion,Fecha_acabar,Observaciones,Fecha_registro")] TablaCitasPaciente tablaCitasPaciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablaCitasPaciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablaCitasPaciente);
        }

        // GET: TablaCitasPacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaCitasPaciente = await _context.TablaCitasPaciente.FindAsync(id);
            if (tablaCitasPaciente == null)
            {
                return NotFound();
            }
            ViewData["Paciente"] = new SelectList(_context.TablaPaciente, "Id", "Nombre");
            ViewData["Profesional"] = new SelectList(_context.TablaProfesional, "id", "nombre");
            return View(tablaCitasPaciente);
        }

        // POST: TablaCitasPacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TablaPacienteId,TablaProfesionalId,Fecha_atencion,Fecha_acabar,Observaciones,Fecha_registro")] TablaCitasPaciente tablaCitasPaciente)
        {
            if (id != tablaCitasPaciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaCitasPaciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaCitasPacienteExists(tablaCitasPaciente.Id))
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
            return View(tablaCitasPaciente);
        }

        // GET: TablaCitasPacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaCitasPaciente = await _context.TablaCitasPaciente.Include(x => x.TablaPaciente).Include(x => x.TablaProfesional)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaCitasPaciente == null)
            {
                return NotFound();
            }

            return View(tablaCitasPaciente);
        }

        // POST: TablaCitasPacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablaCitasPaciente = await _context.TablaCitasPaciente.FindAsync(id);
            _context.TablaCitasPaciente.Remove(tablaCitasPaciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaCitasPacienteExists(int id)
        {
            return _context.TablaCitasPaciente.Any(e => e.Id == id);
        }
    }
}
