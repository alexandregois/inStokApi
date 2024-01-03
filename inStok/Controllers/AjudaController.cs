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
    public class AjudaController : ControllerBase
    {
        private readonly InStockContext _context;

        public AjudaController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/Ajuda
        [HttpGet]
        public ActionResult<IEnumerable<Ajudum>> GetAjudas()
        {
            return _context.Ajuda.ToList();
        }

        // GET: api/Ajuda/5
        [HttpGet("{id}")]
        public ActionResult<Ajudum> GetAjuda(int id)
        {
            var ajudum = _context.Ajuda.Find(id);

            if (ajudum == null)
            {
                return NotFound();
            }

            return ajudum;
        }

        // POST: api/Ajuda
        [HttpPost]
        public ActionResult<Ajudum> PostAjuda(Ajudum ajudum)
        {
            _context.Ajuda.Add(ajudum);
            _context.SaveChanges();

            return CreatedAtAction("GetAjudum", new { id = ajudum.AjudaId }, ajudum);
        }

        // PUT: api/Ajuda/5
        [HttpPut("{id}")]
        public IActionResult PutAjuda(int id, Ajudum ajudum)
        {
            if (id != ajudum.AjudaId)
            {
                return BadRequest();
            }

            _context.Entry(ajudum).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Ajuda/5
        [HttpDelete("{id}")]
        public ActionResult<Ajudum> DeleteAjuda(int id)
        {
            var ajudum = _context.Ajuda.Find(id);
            if (ajudum == null)
            {
                return NotFound();
            }

            _context.Ajuda.Remove(ajudum);
            _context.SaveChanges();

            return ajudum;
        }
    }
}
