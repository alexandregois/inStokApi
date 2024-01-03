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
    public class CategoriaController : ControllerBase
    {
        private readonly InStockContext _context;

        public CategoriaController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/Categoria
        [HttpGet]
        public ActionResult<IEnumerable<Categorium>> GetCategoria()
        {
            return _context.Categoria.ToList();
        }

        // GET: api/Categoria/5
        [HttpGet("{id}")]
        public ActionResult<Categorium> GetCategoria(int id)
        {
            var categorium = _context.Categoria.Find(id);

            if (categorium == null)
            {
                return NotFound();
            }

            return categorium;
        }

        // POST: api/Categoria
        [HttpPost]
        public ActionResult<Categorium> PostCategoria(Categorium categorium)
        {
            _context.Categoria.Add(categorium);
            _context.SaveChanges();

            return CreatedAtAction("GetCategorium", new { id = categorium.CategoriaId }, categorium);
        }

        // PUT: api/Categoria/5
        [HttpPut("{id}")]
        public IActionResult PutCategoria(int id, Categorium categorium)
        {
            if (id != categorium.CategoriaId)
            {
                return BadRequest();
            }

            _context.Entry(categorium).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Categoria/5
        [HttpDelete("{id}")]
        public ActionResult<Categorium> DeleteCategoria(int id)
        {
            var categorium = _context.Categoria.Find(id);
            if (categorium == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(categorium);
            _context.SaveChanges();

            return categorium;
        }
    }
}
