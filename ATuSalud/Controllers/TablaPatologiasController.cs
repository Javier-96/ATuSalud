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
    public class TablaPatologiasController : Controller
    {
        private readonly Contexto _context;

        public TablaPatologiasController(Contexto context)
        {
            _context = context;
        }

        // GET: TablaPatologias
        public async Task<IActionResult> Index()
        {
            return PartialView(await _context.TablaPatologias.Include("Paciente").Include("TablaCodigoCIAP").ToListAsync());
        }

        // GET: TablaPatologias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaPatologias = await _context.TablaPatologias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaPatologias == null)
            {
                return NotFound();
            }

            return View(tablaPatologias);
        }

        // GET: TablaPatologias/Create
        public IActionResult Create()
        {
            ViewData["PacienteID"] = new SelectList(_context.TablaPaciente, "Id", "Nombre");
           

            ViewData["TablaCodigoCIAPId"] = new SelectList(_context.TablaCodigoCiap, "Id", "Codigo");
            return View();
        }

        // POST: TablaPatologias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Id_paciente,TablaCodigoCIAPId")] TablaPatologias tablaPatologias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablaPatologias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablaPatologias);
        }

        // GET: TablaPatologias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaPatologias = await _context.TablaPatologias.FindAsync(id);
            if (tablaPatologias == null)
            {
                return NotFound();
            }
            return View(tablaPatologias);
        }

        // POST: TablaPatologias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Id_paciente,TablaCodigoCIAPId")] TablaPatologias tablaPatologias)
        {
            if (id != tablaPatologias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaPatologias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaPatologiasExists(tablaPatologias.Id))
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
            return View(tablaPatologias);
        }

        // GET: TablaPatologias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaPatologias = await _context.TablaPatologias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaPatologias == null)
            {
                return NotFound();
            }

            return View(tablaPatologias);
        }

        // POST: TablaPatologias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablaPatologias = await _context.TablaPatologias.FindAsync(id);
            _context.TablaPatologias.Remove(tablaPatologias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaPatologiasExists(int id)
        {
            return _context.TablaPatologias.Any(e => e.Id == id);
        }
    }
}
