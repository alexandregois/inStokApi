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
    public class FrequenciaController : ControllerBase
    {
        private readonly InStockContext _context;

        public FrequenciaController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/Frequencia
        [HttpGet]
        public ActionResult<IEnumerable<Frequencium>> GetFrequencia()
        {
            return _context.Frequencia.ToList();
        }

        // GET: api/Frequencia/5
        [HttpGet("{id}")]
        public ActionResult<Frequencium> GetFrequencia(int id)
        {
            var frequencium = _context.Frequencia.Find(id);

            if (frequencium == null)
            {
                return NotFound();
            }

            return frequencium;
        }

        // POST: api/Frequencia
        [HttpPost]
        public ActionResult<Frequencium> PostFrequencia(Frequencium frequencium)
        {
            _context.Frequencia.Add(frequencium);
            _context.SaveChanges();

            return CreatedAtAction("GetFrequencium", new { id = frequencium.FrequenciaId }, frequencium);
        }

        // PUT: api/Frequencia/5
        [HttpPut("{id}")]
        public IActionResult PutFrequencia(int id, Frequencium frequencium)
        {
            if (id != frequencium.FrequenciaId)
            {
                return BadRequest();
            }

            _context.Entry(frequencium).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Frequencia/5
        [HttpDelete("{id}")]
        public ActionResult<Frequencium> DeleteFrequencia(int id)
        {
            var frequencium = _context.Frequencia.Find(id);
            if (frequencium == null)
            {
                return NotFound();
            }

            _context.Frequencia.Remove(frequencium);
            _context.SaveChanges();

            return frequencium;
        }
    }
}
