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
    public class PostagemController : ControllerBase
    {
        private readonly InStockContext _context;

        public PostagemController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/Postagem
        [HttpGet]
        public ActionResult<IEnumerable<Postagem>> GetPostagens()
        {
            return _context.Postagems.ToList();
        }

        // GET: api/Postagem/5
        [HttpGet("{id}")]
        public ActionResult<Postagem> GetPostagem(int id)
        {
            var postagem = _context.Postagems.Find(id);

            if (postagem == null)
            {
                return NotFound();
            }

            return postagem;
        }

        // POST: api/Postagem
        [HttpPost]
        public ActionResult<Postagem> PostPostagem(Postagem postagem)
        {
            _context.Postagems.Add(postagem);
            _context.SaveChanges();

            return CreatedAtAction("GetPostagem", new { id = postagem.PostagemId }, postagem);
        }

        // PUT: api/Postagem/5
        [HttpPut("{id}")]
        public IActionResult PutPostagem(int id, Postagem postagem)
        {
            if (id != postagem.PostagemId)
            {
                return BadRequest();
            }

            _context.Entry(postagem).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Postagem/5
        [HttpDelete("{id}")]
        public ActionResult<Postagem> DeletePostagem(int id)
        {
            var postagem = _context.Postagems.Find(id);
            if (postagem == null)
            {
                return NotFound();
            }

            _context.Postagems.Remove(postagem);
            _context.SaveChanges();

            return postagem;
        }
    }
}
