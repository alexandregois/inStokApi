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
    public class ComentarioController : ControllerBase
    {
        private readonly InStockContext _context;

        public ComentarioController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/Comentario
        [HttpGet]
        public ActionResult<IEnumerable<Comentario>> GetComentarios()
        {
            return _context.Comentarios.ToList();
        }

        // GET: api/Comentario/5
        [HttpGet("{id}")]
        public ActionResult<Comentario> GetComentario(int id)
        {
            var comentario = _context.Comentarios.Find(id);

            if (comentario == null)
            {
                return NotFound();
            }

            return comentario;
        }

        // POST: api/Comentario
        [HttpPost]
        public ActionResult<Comentario> PostComentario(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            _context.SaveChanges();

            return CreatedAtAction("GetComentario", new { id = comentario.ComentarioId }, comentario);
        }

        // PUT: api/Comentario/5
        [HttpPut("{id}")]
        public IActionResult PutComentario(int id, Comentario comentario)
        {
            if (id != comentario.ComentarioId)
            {
                return BadRequest();
            }

            _context.Entry(comentario).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Comentario/5
        [HttpDelete("{id}")]
        public ActionResult<Comentario> DeleteComentario(int id)
        {
            var comentario = _context.Comentarios.Find(id);
            if (comentario == null)
            {
                return NotFound();
            }

            _context.Comentarios.Remove(comentario);
            _context.SaveChanges();

            return comentario;
        }
    }
}
