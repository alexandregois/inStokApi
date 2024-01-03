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
    public class MuralSonhoController : ControllerBase
    {
        private readonly InStockContext _context;

        public MuralSonhoController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/MuralSonho
        [HttpGet]
        public ActionResult<IEnumerable<MuralSonho>> GetMuraisSonhos()
        {
            return _context.MuralSonhos.ToList();
        }

        // GET: api/MuralSonho/5
        [HttpGet("{id}")]
        public ActionResult<MuralSonho> GetMuralSonho(int id)
        {
            var muralSonho = _context.MuralSonhos.Find(id);

            if (muralSonho == null)
            {
                return NotFound();
            }

            return muralSonho;
        }

        // POST: api/MuralSonho
        [HttpPost]
        public ActionResult<MuralSonho> PostMuralSonho(MuralSonho muralSonho)
        {
            _context.MuralSonhos.Add(muralSonho);
            _context.SaveChanges();

            return CreatedAtAction("GetMuralSonho", new { id = muralSonho.MuralId }, muralSonho);
        }

        // PUT: api/MuralSonho/5
        [HttpPut("{id}")]
        public IActionResult PutMuralSonho(int id, MuralSonho muralSonho)
        {
            if (id != muralSonho.MuralId)
            {
                return BadRequest();
            }

            _context.Entry(muralSonho).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/MuralSonho/5
        [HttpDelete("{id}")]
        public ActionResult<MuralSonho> DeleteMuralSonho(int id)
        {
            var muralSonho = _context.MuralSonhos.Find(id);
            if (muralSonho == null)
            {
                return NotFound();
            }

            _context.MuralSonhos.Remove(muralSonho);
            _context.SaveChanges();

            return muralSonho;
        }
    }
}
