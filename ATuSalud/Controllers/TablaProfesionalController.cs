using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ATuSalud.Models;
using ConexionSQL.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using ATuSalud.ViewData;
using Demostracion;

namespace ATuSalud.Controllers
{
    public class TablaProfesionalController : Controller
    {
        //Accede a la base de datos
        private readonly Contexto _context;
        //Ahorrar algoritmo recorrido etc
        private readonly ServicioSQL _sql;
        public TablaProfesionalController(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }

        // GET: TablaProfesional
        public async Task<IActionResult> Index()
        {
            return View(await _context.TablaProfesional.ToListAsync());
        }

        // GET: TablaProfesional/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaProfesional = await _context.TablaProfesional
                .FirstOrDefaultAsync(m => m.id == id);
            if (tablaProfesional == null)
            {
                return NotFound();
            }

            return View(tablaProfesional);
        }

        // GET: TablaProfesional/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TablaProfesional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TablaProfesional tablaProfesional, IFormFile fichero)
        {
            if (ModelState.IsValid)
            {
                if (fichero != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        fichero.CopyTo(ms);
                        tablaProfesional.foto = ms.ToArray();
                    }
                }
                _context.Add(tablaProfesional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablaProfesional);
        }

        // GET: TablaProfesional/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaProfesional = await _context.TablaProfesional.FindAsync(id);
            if (tablaProfesional == null)
            {
                return NotFound();
            }
            return View(tablaProfesional);
        }

        // POST: TablaProfesional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,apellido1,apellido2,especialidad,num_colegiado,foto")] TablaProfesional tablaProfesional, IFormFile fichero)
        {
            if (id != tablaProfesional.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (fichero != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            fichero.CopyTo(ms);
                            tablaProfesional.foto = ms.ToArray();
                        }
                    }
                    _context.Update(tablaProfesional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaProfesionalExists(tablaProfesional.id))
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
            return View(tablaProfesional);
        }

        // GET: TablaProfesional/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaProfesional = await _context.TablaProfesional
                .FirstOrDefaultAsync(m => m.id == id);
            if (tablaProfesional == null)
            {
                return NotFound();
            }

            return View(tablaProfesional);
        }

        // POST: TablaProfesional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablaProfesional = await _context.TablaProfesional.FindAsync(id);
            _context.TablaProfesional.Remove(tablaProfesional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaProfesionalExists(int id)
        {
            return _context.TablaProfesional.Any(e => e.id == id);
        }

        public IActionResult MostrarImagen(int id)
        {
            TablaProfesional i = _context.TablaProfesional.Find(id);
            return File(i.foto, "image/jpeg");
        }
    }
}
