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
    public class HistoricoFrequenciaController : ControllerBase
    {
        private readonly InStockContext _context;

        public HistoricoFrequenciaController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/HistoricoFrequencia
        [HttpGet]
        public ActionResult<IEnumerable<HistoricoFrequencium>> GetHistoricoFrequencia()
        {
            return _context.HistoricoFrequencia.ToList();
        }

        // GET: api/HistoricoFrequencia/5
        [HttpGet("{id}")]
        public ActionResult<HistoricoFrequencium> GetHistoricoFrequencia(int id)
        {
            var historicoFrequencium = _context.HistoricoFrequencia.Find(id);

            if (historicoFrequencium == null)
            {
                return NotFound();
            }

            return historicoFrequencium;
        }

        // POST: api/HistoricoFrequencia
        [HttpPost]
        public ActionResult<HistoricoFrequencium> PostHistoricoFrequencia(HistoricoFrequencium historicoFrequencium)
        {
            _context.HistoricoFrequencia.Add(historicoFrequencium);
            _context.SaveChanges();

            return CreatedAtAction("GetHistoricoFrequencium", new { id = historicoFrequencium.HistoricoId }, historicoFrequencium);
        }

        // PUT: api/HistoricoFrequencia/5
        [HttpPut("{id}")]
        public IActionResult PutHistoricoFrequencia(int id, HistoricoFrequencium historicoFrequencium)
        {
            if (id != historicoFrequencium.FrequenciaId)
            {
                return BadRequest();
            }

            _context.Entry(historicoFrequencium).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/HistoricoFrequencia/5
        [HttpDelete("{id}")]
        public ActionResult<HistoricoFrequencium> DeleteHistoricoFrequencia(int id)
        {
            var historicoFrequencium = _context.HistoricoFrequencia.Find(id);
            if (historicoFrequencium == null)
            {
                return NotFound();
            }

            _context.HistoricoFrequencia.Remove(historicoFrequencium);
            _context.SaveChanges();

            return historicoFrequencium;
        }
    }
}
