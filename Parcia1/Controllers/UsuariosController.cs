using Parcia1.Data;
using Parcia1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Parcia1.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Usuario.Include(u => u.RolUsuario);
            return View(await appDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuario
                .Include(u => u.RolUsuario)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);

            if (usuario == null) return NotFound();

            return View(usuario);
        }

        public IActionResult Create()
        {
            ViewData["RolUsuarioId"] = new SelectList(_context.RolUsuario, "RolUsuarioId", "Rol");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,Nombre,RolUsuarioId,Telefono,correo,Direccion,FechaRegistro")] Usuario usuario)
        {
            if (usuario.FechaRegistro == default)
            {
                usuario.FechaRegistro = DateTime.Now;
            }

            ModelState.Remove("RolUsuario");
            ModelState.Remove("Envio");

            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["RolUsuarioId"] = new SelectList(_context.RolUsuario, "Id", "Nombre", usuario.RolUsuarioId);
            return View(usuario);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            ViewData["RolUsuarioId"] = new SelectList(_context.RolUsuario, "RolUsuarioId", "Rol", usuario.RolUsuarioId); // <--- IMPORTANTE

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,Nombre,RolUsuarioId,Telefono,correo,Direccion,FechaRegistro")] Usuario usuario)
        {

            if (id != usuario.UsuarioId)
            {
                return NotFound();
            }

            
            ModelState.Remove("RolUsuario");
            ModelState.Remove("Envio");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.UsuarioId))
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

            ViewData["RolUsuarioId"] = new SelectList(_context.RolUsuario, "RolUsuarioId", "Rol", usuario.RolUsuarioId); // <--- IMPORTANTE

            return View(usuario);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuario
                .Include(u => u.RolUsuario)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);

            if (usuario == null) return NotFound();

            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.UsuarioId == id);
        }
    }
}
