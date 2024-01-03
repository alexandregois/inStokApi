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
    public class ImagemController : ControllerBase
    {
        private readonly InStockContext _context;

        public ImagemController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/Imagem
        [HttpGet]
        public ActionResult<IEnumerable<Imagem>> GetImagens()
        {
            return _context.Imagems.ToList();
        }

        // GET: api/Imagem/5
        [HttpGet("{id}")]
        public ActionResult<Imagem> GetImagem(int id)
        {
            var imagem = _context.Imagems.Find(id);

            if (imagem == null)
            {
                return NotFound();
            }

            return imagem;
        }

        // POST: api/Imagem
        [HttpPost]
        public ActionResult<Imagem> PostImagem(Imagem imagem)
        {
            _context.Imagems.Add(imagem);
            _context.SaveChanges();

            return CreatedAtAction("GetImagem", new { id = imagem.ImagemId }, imagem);
        }

        // PUT: api/Imagem/5
        [HttpPut("{id}")]
        public IActionResult PutImagem(int id, Imagem imagem)
        {
            if (id != imagem.ImagemId)
            {
                return BadRequest();
            }

            _context.Entry(imagem).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Imagem/5
        [HttpDelete("{id}")]
        public ActionResult<Imagem> DeleteImagem(int id)
        {
            var imagem = _context.Imagems.Find(id);
            if (imagem == null)
            {
                return NotFound();
            }

            _context.Imagems.Remove(imagem);
            _context.SaveChanges();

            return imagem;
        }
    }
}
