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
    public class AulaController : ControllerBase
    {
        private readonly InStockContext _context;

        public AulaController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/Aula
        [HttpGet]
        public ActionResult<IEnumerable<Aula>> GetAulas()
        {
            return _context.Aulas.ToList();
        }

        // GET: api/Aula/5
        [HttpGet("{id}")]
        public ActionResult<Aula> GetAula(int id)
        {
            var aula = _context.Aulas.Find(id);

            if (aula == null)
            {
                return NotFound();
            }

            return aula;
        }

        // POST: api/Aula
        [HttpPost]
        public ActionResult<Aula> PostAula(Aula aula)
        {
            _context.Aulas.Add(aula);
            _context.SaveChanges();

            return CreatedAtAction("GetAula", new { id = aula.AulaId }, aula);
        }

        // PUT: api/Aula/5
        [HttpPut("{id}")]
        public IActionResult PutAula(int id, Aula aula)
        {
            if (id != aula.AulaId)
            {
                return BadRequest();
            }

            _context.Entry(aula).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Aula/5
        [HttpDelete("{id}")]
        public ActionResult<Aula> DeleteAula(int id)
        {
            var aula = _context.Aulas.Find(id);
            if (aula == null)
            {
                return NotFound();
            }

            _context.Aulas.Remove(aula);
            _context.SaveChanges();

            return aula;
        }
    }
}
