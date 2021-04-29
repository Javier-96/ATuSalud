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
    public class TablaCodigoCiapsController : Controller
    {
        private readonly Contexto _context;

        public TablaCodigoCiapsController(Contexto context)
        {
            _context = context;
        }

        // GET: TablaCodigoCiaps
        public async Task<IActionResult> Index()
        {
            return View(await _context.TablaCodigoCiap.ToListAsync());
        }

        // GET: TablaCodigoCiaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaCodigoCiap = await _context.TablaCodigoCiap
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaCodigoCiap == null)
            {
                return NotFound();
            }

            return View(tablaCodigoCiap);
        }

        // GET: TablaCodigoCiaps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TablaCodigoCiaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Color,Enfermedad")] TablaCodigoCiap tablaCodigoCiap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablaCodigoCiap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablaCodigoCiap);
        }

        // GET: TablaCodigoCiaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaCodigoCiap = await _context.TablaCodigoCiap.FindAsync(id);
            if (tablaCodigoCiap == null)
            {
                return NotFound();
            }
            return View(tablaCodigoCiap);
        }

        // POST: TablaCodigoCiaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Color,Enfermedad")] TablaCodigoCiap tablaCodigoCiap)
        {
            if (id != tablaCodigoCiap.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaCodigoCiap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaCodigoCiapExists(tablaCodigoCiap.Id))
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
            return View(tablaCodigoCiap);
        }

        // GET: TablaCodigoCiaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaCodigoCiap = await _context.TablaCodigoCiap
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaCodigoCiap == null)
            {
                return NotFound();
            }

            return View(tablaCodigoCiap);
        }

        // POST: TablaCodigoCiaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablaCodigoCiap = await _context.TablaCodigoCiap.FindAsync(id);
            _context.TablaCodigoCiap.Remove(tablaCodigoCiap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaCodigoCiapExists(int id)
        {
            return _context.TablaCodigoCiap.Any(e => e.Id == id);
        }
    }
}
