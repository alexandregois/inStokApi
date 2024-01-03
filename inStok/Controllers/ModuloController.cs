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
    public class ModuloController : ControllerBase
    {
        private readonly InStockContext _context;

        public ModuloController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/Modulo
        [HttpGet]
        public ActionResult<IEnumerable<Modulo>> GetModulos()
        {
            return _context.Modulos.ToList();
        }

        // GET: api/Modulo/5
        [HttpGet("{id}")]
        public ActionResult<Modulo> GetModulo(int id)
        {
            var modulo = _context.Modulos.Find(id);

            if (modulo == null)
            {
                return NotFound();
            }

            return modulo;
        }

        // POST: api/Modulo
        [HttpPost]
        public ActionResult<Modulo> PostModulo(Modulo modulo)
        {
            _context.Modulos.Add(modulo);
            _context.SaveChanges();

            return CreatedAtAction("GetModulo", new { id = modulo.ModuloId }, modulo);
        }

        // PUT: api/Modulo/5
        [HttpPut("{id}")]
        public IActionResult PutModulo(int id, Modulo modulo)
        {
            if (id != modulo.ModuloId)
            {
                return BadRequest();
            }

            _context.Entry(modulo).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Modulo/5
        [HttpDelete("{id}")]
        public ActionResult<Modulo> DeleteModulo(int id)
        {
            var modulo = _context.Modulos.Find(id);
            if (modulo == null)
            {
                return NotFound();
            }

            _context.Modulos.Remove(modulo);
            _context.SaveChanges();

            return modulo;
        }
    }
}
