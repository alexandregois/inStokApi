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
    public class HistoricoAulaController : ControllerBase
    {
        private readonly InStockContext _context;

        public HistoricoAulaController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/HistoricoAula
        [HttpGet]
        public ActionResult<IEnumerable<HistoricoAula>> GetHistoricoAulas()
        {
            return _context.HistoricoAulas.ToList();
        }

        // GET: api/HistoricoAula/5
        [HttpGet("{id}")]
        public ActionResult<HistoricoAula> GetHistoricoAula(int id)
        {
            var historicoAula = _context.HistoricoAulas.Find(id);

            if (historicoAula == null)
            {
                return NotFound();
            }

            return historicoAula;
        }

        // POST: api/HistoricoAula
        [HttpPost]
        public ActionResult<HistoricoAula> PostHistoricoAula(HistoricoAula historicoAula)
        {
            _context.HistoricoAulas.Add(historicoAula);
            _context.SaveChanges();

            return CreatedAtAction("GetHistoricoAula", new { id = historicoAula.HistoricoId }, historicoAula);
        }

        // PUT: api/HistoricoAula/5
        [HttpPut("{id}")]
        public IActionResult PutHistoricoAula(int id, HistoricoAula historicoAula)
        {
            if (id != historicoAula.HistoricoId)
            {
                return BadRequest();
            }

            _context.Entry(historicoAula).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/HistoricoAula/5
        [HttpDelete("{id}")]
        public ActionResult<HistoricoAula> DeleteHistoricoAula(int id)
        {
            var historicoAula = _context.HistoricoAulas.Find(id);
            if (historicoAula == null)
            {
                return NotFound();
            }

            _context.HistoricoAulas.Remove(historicoAula);
            _context.SaveChanges();

            return historicoAula;
        }
    }
}
