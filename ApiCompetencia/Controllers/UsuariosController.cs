using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCompetencia.Context;
using ApiCompetencia.Models;

namespace ApiCompetencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> Getusuarios()
        {
            if (_context.usuarios == null)
            {
                return NotFound();
            }
            return await _context.usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuarios(int id)
        {
            if (_context.usuarios == null)
            {
                return NotFound();
            }
            var usuarios = await _context.usuarios.FindAsync(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            return usuarios;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios(int id, Usuarios usuarios)
        {
            if (id != usuarios.id)
            {
                return BadRequest();
            }

            _context.Entry(usuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult Post([FromForm] Usuarios gestor)
        {
            try
            {
                _context.usuarios.Add(gestor);
                _context.SaveChanges();
                return CreatedAtRoute("GetUsuarios", new { id = gestor.id }, gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarios(int id)
        {
            if (_context.usuarios == null)
            {
                return NotFound();
            }
            var usuarios = await _context.usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            _context.usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("{username}/{password}")]
        public ActionResult<List<Usuarios>> GetIniciarSesion(string username, string password)
        {
            var usuarios = _context.usuarios.Where(usuario => usuario.username.Equals(username) && usuario.password.Equals(password)).ToList();
            if (usuarios == null)
            {
                return NotFound();
            }
            return usuarios;

        }
        private bool UsuariosExists(int id)
        {
            return (_context.usuarios?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}