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
    public class CategoriaTrilhaController : ControllerBase
    {
        private readonly InStockContext _context;

        public CategoriaTrilhaController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/CategoriaTrilha
        [HttpGet]
        public ActionResult<IEnumerable<CategoriaTrilha>> GetCategoriaTrilhas()
        {
            return _context.CategoriaTrilhas.ToList();
        }

        // GET: api/CategoriaTrilha/5
        [HttpGet("{id}")]
        public ActionResult<CategoriaTrilha> GetCategoriaTrilha(int id)
        {
            var categoriaTrilha = _context.CategoriaTrilhas.Find(id);

            if (categoriaTrilha == null)
            {
                return NotFound();
            }

            return categoriaTrilha;
        }

        // POST: api/CategoriaTrilha
        [HttpPost]
        public ActionResult<CategoriaTrilha> PostCategoriaTrilha(CategoriaTrilha categoriaTrilha)
        {
            _context.CategoriaTrilhas.Add(categoriaTrilha);
            _context.SaveChanges();

            return CreatedAtAction("GetCategoriaTrilha", new { id = categoriaTrilha.CategoriaTrilhaId }, categoriaTrilha);
        }

        // PUT: api/CategoriaTrilha/5
        [HttpPut("{id}")]
        public IActionResult PutCategoriaTrilha(int id, CategoriaTrilha categoriaTrilha)
        {
            if (id != categoriaTrilha.CategoriaTrilhaId)
            {
                return BadRequest();
            }

            _context.Entry(categoriaTrilha).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/CategoriaTrilha/5
        [HttpDelete("{id}")]
        public ActionResult<CategoriaTrilha> DeleteCategoriaTrilha(int id)
        {
            var categoriaTrilha = _context.CategoriaTrilhas.Find(id);
            if (categoriaTrilha == null)
            {
                return NotFound();
            }

            _context.CategoriaTrilhas.Remove(categoriaTrilha);
            _context.SaveChanges();

            return categoriaTrilha;
        }
    }
}
