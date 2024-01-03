using Microsoft.AspNetCore.Mvc;
using inStok.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace inStok.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly InStockContext _context;

        public UsuarioController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return _context.Usuarios
                .Include(u => u.Comentarios)
                .Include(p => p.Postagems)
                .Include(h => h.HistoricoAulas).ToList();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuario(int id)
        {
            var usuario = _context.Usuarios
                .Include(u => u.Comentarios)
                .Include(u => u.HistoricoAulas)
                .Include(u => u.HistoricoFrequencia)
                .Include(u => u.Lembretes)
                .Include(u => u.Mentalizacaos)
                .Include(u => u.MuralSonhos)
                .Include(u => u.Notificacaos)
                .Include(u => u.Pagamentos)
                .Include(u => u.Postagems)
                .Include(u => u.Sexo)
                .FirstOrDefault(u => u.UsuarioId == id);

            if (usuario == null)
            {
                return NotFound(); // or whatever response suits your API design
            }

            // Now, you can create a response model based on your Usuario model.
            var responseModel = new Usuario
            {
                // Map properties from usuario to response model
                UsuarioId = usuario.UsuarioId,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataNascimento = usuario.DataNascimento,
                FotoPerfil = usuario.FotoPerfil,
                SexoId = usuario.SexoId,
                Apelido = usuario.Apelido,
                Sobrenome = usuario.Sobrenome,
                Telefone = usuario.Telefone,

                // Map other properties...

                // Map collections
                Comentarios = usuario.Comentarios,
                HistoricoAulas = usuario.HistoricoAulas,
                Postagems = usuario.Postagems,
                HistoricoFrequencia = usuario.HistoricoFrequencia,
                Lembretes = usuario.Lembretes,
                Mentalizacaos = usuario.Mentalizacaos,
                MuralSonhos = usuario.MuralSonhos,
                Notificacaos = usuario.Notificacaos,
                Pagamentos = usuario.Pagamentos,
                Sexo = usuario.Sexo
                // Map other collections...
            };

            return responseModel;
        }
    

        // POST: api/Usuario
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<Usuario> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return CreatedAtAction("GetUsuario", new { id = usuario.UsuarioId }, usuario);
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public IActionResult PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public ActionResult<Usuario> DeleteUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return usuario;
        }
    }
}
