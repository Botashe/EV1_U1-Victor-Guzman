using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mercy_developers.Models;

namespace mercy_developers.Controllers
{
    public class UsuariosServiciosController : Controller
    {
        private readonly MercyDevelopersContext _context;

        public UsuariosServiciosController(MercyDevelopersContext context)
        {
            _context = context;
        }

        // GET: UsuariosServicios
        public async Task<IActionResult> Index()
        {
            var mercyDevelopersContext = _context.UsuariosServicios.Include(u => u.ServiciosIdServNavigation).Include(u => u.UsuariosRutNavigation);
            return View(await mercyDevelopersContext.ToListAsync());
        }

        // GET: UsuariosServicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UsuariosServicios == null)
            {
                return NotFound();
            }

            var usuariosServicio = await _context.UsuariosServicios
                .Include(u => u.ServiciosIdServNavigation)
                .Include(u => u.UsuariosRutNavigation)
                .FirstOrDefaultAsync(m => m.UsuariosRut == id);
            if (usuariosServicio == null)
            {
                return NotFound();
            }

            return View(usuariosServicio);
        }

        // GET: UsuariosServicios/Create
        public IActionResult Create()
        {
            ViewData["ServiciosIdServ"] = new SelectList(_context.Servicios, "IdServ", "IdServ");
            ViewData["UsuariosRut"] = new SelectList(_context.Usuarios, "Rut", "Rut");
            return View();
        }

        // POST: UsuariosServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuariosRut,ServiciosIdServ,Estado,Duracion,NombreTecnico,FechaRegistro,HoraInicio,HoraTermino")] UsuariosServicio usuariosServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuariosServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiciosIdServ"] = new SelectList(_context.Servicios, "IdServ", "IdServ", usuariosServicio.ServiciosIdServ);
            ViewData["UsuariosRut"] = new SelectList(_context.Usuarios, "Rut", "Rut", usuariosServicio.UsuariosRut);
            return View(usuariosServicio);
        }

        // GET: UsuariosServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UsuariosServicios == null)
            {
                return NotFound();
            }

            var usuariosServicio = await _context.UsuariosServicios.FindAsync(id);
            if (usuariosServicio == null)
            {
                return NotFound();
            }
            ViewData["ServiciosIdServ"] = new SelectList(_context.Servicios, "IdServ", "IdServ", usuariosServicio.ServiciosIdServ);
            ViewData["UsuariosRut"] = new SelectList(_context.Usuarios, "Rut", "Rut", usuariosServicio.UsuariosRut);
            return View(usuariosServicio);
        }

        // POST: UsuariosServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuariosRut,ServiciosIdServ,Estado,Duracion,NombreTecnico,FechaRegistro,HoraInicio,HoraTermino")] UsuariosServicio usuariosServicio)
        {
            if (id != usuariosServicio.UsuariosRut)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuariosServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosServicioExists(usuariosServicio.UsuariosRut))
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
            ViewData["ServiciosIdServ"] = new SelectList(_context.Servicios, "IdServ", "IdServ", usuariosServicio.ServiciosIdServ);
            ViewData["UsuariosRut"] = new SelectList(_context.Usuarios, "Rut", "Rut", usuariosServicio.UsuariosRut);
            return View(usuariosServicio);
        }

        // GET: UsuariosServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UsuariosServicios == null)
            {
                return NotFound();
            }

            var usuariosServicio = await _context.UsuariosServicios
                .Include(u => u.ServiciosIdServNavigation)
                .Include(u => u.UsuariosRutNavigation)
                .FirstOrDefaultAsync(m => m.UsuariosRut == id);
            if (usuariosServicio == null)
            {
                return NotFound();
            }

            return View(usuariosServicio);
        }

        // POST: UsuariosServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UsuariosServicios == null)
            {
                return Problem("Entity set 'MercyDevelopersContext.UsuariosServicios'  is null.");
            }
            var usuariosServicio = await _context.UsuariosServicios.FindAsync(id);
            if (usuariosServicio != null)
            {
                _context.UsuariosServicios.Remove(usuariosServicio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosServicioExists(int id)
        {
          return (_context.UsuariosServicios?.Any(e => e.UsuariosRut == id)).GetValueOrDefault();
        }
    }
}
