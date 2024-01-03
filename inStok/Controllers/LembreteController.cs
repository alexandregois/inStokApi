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
    public class LembreteController : ControllerBase
    {
        private readonly InStockContext _context;

        public LembreteController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/Lembrete
        [HttpGet]
        public ActionResult<IEnumerable<Lembrete>> GetLembretes()
        {
            return _context.Lembretes.ToList();
        }

        // GET: api/Lembrete/5
        [HttpGet("{id}")]
        public ActionResult<Lembrete> GetLembrete(int id)
        {
            var lembrete = _context.Lembretes.Find(id);

            if (lembrete == null)
            {
                return NotFound();
            }

            return lembrete;
        }

        // POST: api/Lembrete
        [HttpPost]
        public ActionResult<Lembrete> PostLembrete(Lembrete lembrete)
        {
            _context.Lembretes.Add(lembrete);
            _context.SaveChanges();

            return CreatedAtAction("GetLembrete", new { id = lembrete.LembreteId }, lembrete);
        }

        // PUT: api/Lembrete/5
        [HttpPut("{id}")]
        public IActionResult PutLembrete(int id, Lembrete lembrete)
        {
            if (id != lembrete.LembreteId)
            {
                return BadRequest();
            }

            _context.Entry(lembrete).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Lembrete/5
        [HttpDelete("{id}")]
        public ActionResult<Lembrete> DeleteLembrete(int id)
        {
            var lembrete = _context.Lembretes.Find(id);
            if (lembrete == null)
            {
                return NotFound();
            }

            _context.Lembretes.Remove(lembrete);
            _context.SaveChanges();

            return lembrete;
        }
    }
}
