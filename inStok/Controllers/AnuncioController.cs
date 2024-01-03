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
    public class AnuncioController : ControllerBase
    {
        private readonly InStockContext _context;

        public AnuncioController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/Anuncio
        [HttpGet]
        public ActionResult<IEnumerable<Anuncio>> GetAnuncios()
        {
            return _context.Anuncios.ToList();
        }

        // GET: api/Anuncio/5
        [HttpGet("{id}")]
        public ActionResult<Anuncio> GetAnuncio(int id)
        {
            var anuncio = _context.Anuncios.Find(id);

            if (anuncio == null)
            {
                return NotFound();
            }

            return anuncio;
        }

        // POST: api/Anuncio
        [HttpPost]
        public ActionResult<Anuncio> PostAnuncio(Anuncio anuncio)
        {
            _context.Anuncios.Add(anuncio);
            _context.SaveChanges();

            return CreatedAtAction("GetAnuncio", new { id = anuncio.AnuncioId }, anuncio);
        }

        // PUT: api/Anuncio/5
        [HttpPut("{id}")]
        public IActionResult PutAnuncio(int id, Anuncio anuncio)
        {
            if (id != anuncio.AnuncioId)
            {
                return BadRequest();
            }

            _context.Entry(anuncio).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Anuncio/5
        [HttpDelete("{id}")]
        public ActionResult<Anuncio> DeleteAnuncio(int id)
        {
            var anuncio = _context.Anuncios.Find(id);
            if (anuncio == null)
            {
                return NotFound();
            }

            _context.Anuncios.Remove(anuncio);
            _context.SaveChanges();

            return anuncio;
        }
    }
}
