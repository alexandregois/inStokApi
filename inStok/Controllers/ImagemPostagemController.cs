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
    public class ImagemPostagemController : ControllerBase
    {
        private readonly InStockContext _context;

        public ImagemPostagemController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/ImagemPostagem
        [HttpGet]
        public ActionResult<IEnumerable<ImagemPostagem>> GetImagemPostagens()
        {
            return _context.ImagemPostagems.ToList();
        }

        // GET: api/ImagemPostagem/5
        [HttpGet("{id}")]
        public ActionResult<ImagemPostagem> GetImagemPostagem(int id)
        {
            var imagemPostagem = _context.ImagemPostagems.Find(id);

            if (imagemPostagem == null)
            {
                return NotFound();
            }

            return imagemPostagem;
        }

        // POST: api/ImagemPostagem
        [HttpPost]
        public ActionResult<ImagemPostagem> PostImagemPostagem(ImagemPostagem imagemPostagem)
        {
            _context.ImagemPostagems.Add(imagemPostagem);
            _context.SaveChanges();

            return CreatedAtAction("GetImagemPostagem", new { id = imagemPostagem.ImagemPostagemId }, imagemPostagem);
        }

        // PUT: api/ImagemPostagem/5
        [HttpPut("{id}")]
        public IActionResult PutImagemPostagem(int id, ImagemPostagem imagemPostagem)
        {
            if (id != imagemPostagem.ImagemPostagemId)
            {
                return BadRequest();
            }

            _context.Entry(imagemPostagem).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/ImagemPostagem/5
        [HttpDelete("{id}")]
        public ActionResult<ImagemPostagem> DeleteImagemPostagem(int id)
        {
            var imagemPostagem = _context.ImagemPostagems.Find(id);
            if (imagemPostagem == null)
            {
                return NotFound();
            }

            _context.ImagemPostagems.Remove(imagemPostagem);
            _context.SaveChanges();

            return imagemPostagem;
        }
    }
}
