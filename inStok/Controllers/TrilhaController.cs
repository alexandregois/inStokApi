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
    public class TrilhaController : ControllerBase
    {
        private readonly InStockContext _context;

        public TrilhaController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/Trilha
        [HttpGet]
        public ActionResult<IEnumerable<Trilha>> GetTrilhas()
        {
            return _context.Trilhas.ToList();
        }

        // GET: api/Trilha/5
        [HttpGet("{id}")]
        public ActionResult<Trilha> GetTrilha(int id)
        {
            var trilha = _context.Trilhas.Find(id);

            if (trilha == null)
            {
                return NotFound();
            }

            return trilha;
        }

        // POST: api/Trilha
        [HttpPost]
        public ActionResult<Trilha> PostTrilha(Trilha trilha)
        {
            _context.Trilhas.Add(trilha);
            _context.SaveChanges();

            return CreatedAtAction("GetTrilha", new { id = trilha.TrilhaId }, trilha);
        }

        // PUT: api/Trilha/5
        [HttpPut("{id}")]
        public IActionResult PutTrilha(int id, Trilha trilha)
        {
            if (id != trilha.TrilhaId)
            {
                return BadRequest();
            }

            _context.Entry(trilha).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Trilha/5
        [HttpDelete("{id}")]
        public ActionResult<Trilha> DeleteTrilha(int id)
        {
            var trilha = _context.Trilhas.Find(id);
            if (trilha == null)
            {
                return NotFound();
            }

            _context.Trilhas.Remove(trilha);
            _context.SaveChanges();

            return trilha;
        }
    }
}
