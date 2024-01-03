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
    public class PostagemCategoriaController : ControllerBase
    {
        private readonly InStockContext _context;

        public PostagemCategoriaController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/PostagemCategoria
        [HttpGet]
        public ActionResult<IEnumerable<PostagemCategorium>> GetPostagemCategoria()
        {
            return _context.PostagemCategoria.ToList();
        }

        // GET: api/PostagemCategoria/5
        [HttpGet("{id}")]
        public ActionResult<PostagemCategorium> GetPostagemCategoria(int id)
        {
            var postagemCategorium = _context.PostagemCategoria.Find(id);

            if (postagemCategorium == null)
            {
                return NotFound();
            }

            return postagemCategorium;
        }

        // POST: api/PostagemCategoria
        [HttpPost]
        public ActionResult<PostagemCategorium> PostPostagemCategoria(PostagemCategorium postagemCategorium)
        {
            _context.PostagemCategoria.Add(postagemCategorium);
            _context.SaveChanges();

            return CreatedAtAction("GetPostagemCategorium", new { id = postagemCategorium.CategoriaId }, postagemCategorium);
        }

        // PUT: api/PostagemCategoria/5
        [HttpPut("{id}")]
        public IActionResult PutPostagemCategoria(int id, PostagemCategorium postagemCategorium)
        {
            if (id != postagemCategorium.CategoriaId)
            {
                return BadRequest();
            }

            _context.Entry(postagemCategorium).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/PostagemCategoria/5
        [HttpDelete("{id}")]
        public ActionResult<PostagemCategorium> DeletePostagemCategoria(int id)
        {
            var postagemCategorium = _context.PostagemCategoria.Find(id);
            if (postagemCategorium == null)
            {
                return NotFound();
            }

            _context.PostagemCategoria.Remove(postagemCategorium);
            _context.SaveChanges();

            return postagemCategorium;
        }
    }
}
