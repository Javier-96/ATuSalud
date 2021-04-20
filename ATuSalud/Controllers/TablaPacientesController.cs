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
    public class TablaPacientesController : Controller
    {
        private readonly Contexto _context;

        public TablaPacientesController(Contexto context)
        {
            _context = context;
        }

        // GET: TablaPacientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TablaPaciente.ToListAsync());
        }

        // GET: TablaPacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaPaciente = await _context.TablaPaciente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaPaciente == null)
            {
                return NotFound();
            }

            return View(tablaPaciente);
        }

        // GET: TablaPacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TablaPacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido1,Apellido2,Fecha_de_nacimiento,Seguro_privado,DNI,Direccion_postal,telefono_fijo,telefono_movil_1,telefono_movil_2,Sexo")] TablaPaciente tablaPaciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablaPaciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablaPaciente);
        }

        // GET: TablaPacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaPaciente = await _context.TablaPaciente.FindAsync(id);
            if (tablaPaciente == null)
            {
                return NotFound();
            }
            return View(tablaPaciente);
        }

        // POST: TablaPacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido1,Apellido2,Fecha_de_nacimiento,Seguro_privado,DNI,Direccion_postal,telefono_fijo,telefono_movil_1,telefono_movil_2,Sexo")] TablaPaciente tablaPaciente)
        {
            if (id != tablaPaciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaPaciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaPacienteExists(tablaPaciente.Id))
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
            return View(tablaPaciente);
        }

        // GET: TablaPacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaPaciente = await _context.TablaPaciente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaPaciente == null)
            {
                return NotFound();
            }

            return View(tablaPaciente);
        }

        // POST: TablaPacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablaPaciente = await _context.TablaPaciente.FindAsync(id);
            _context.TablaPaciente.Remove(tablaPaciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaPacienteExists(int id)
        {
            return _context.TablaPaciente.Any(e => e.Id == id);
        }
    }
}
