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
    public class TablaRegistroCuentasController : Controller
    {
        private readonly Contexto _context;

        public TablaRegistroCuentasController(Contexto context)
        {
            _context = context;
        }

        // GET: TablaRegistroCuentas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TablaRegistroCuenta.ToListAsync());
        }

        // GET: TablaRegistroCuentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaRegistroCuenta = await _context.TablaRegistroCuenta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaRegistroCuenta == null)
            {
                return NotFound();
            }

            return View(tablaRegistroCuenta);
        }

        // GET: TablaRegistroCuentas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TablaRegistroCuentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,emailAddress,telefono,Especialidad,primeraPassword,segundaPassword")] TablaRegistroCuenta tablaRegistroCuenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablaRegistroCuenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablaRegistroCuenta);
        }

        // GET: TablaRegistroCuentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaRegistroCuenta = await _context.TablaRegistroCuenta.FindAsync(id);
            if (tablaRegistroCuenta == null)
            {
                return NotFound();
            }
            return View(tablaRegistroCuenta);
        }

        // POST: TablaRegistroCuentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,emailAddress,telefono,Especialidad,primeraPassword,segundaPassword")] TablaRegistroCuenta tablaRegistroCuenta)
        {
            if (id != tablaRegistroCuenta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaRegistroCuenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaRegistroCuentaExists(tablaRegistroCuenta.Id))
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
            return View(tablaRegistroCuenta);
        }

        // GET: TablaRegistroCuentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaRegistroCuenta = await _context.TablaRegistroCuenta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaRegistroCuenta == null)
            {
                return NotFound();
            }

            return View(tablaRegistroCuenta);
        }

        // POST: TablaRegistroCuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablaRegistroCuenta = await _context.TablaRegistroCuenta.FindAsync(id);
            _context.TablaRegistroCuenta.Remove(tablaRegistroCuenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaRegistroCuentaExists(int id)
        {
            return _context.TablaRegistroCuenta.Any(e => e.Id == id);
        }
    }
}
