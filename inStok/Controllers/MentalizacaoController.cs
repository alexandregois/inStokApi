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
    public class MentalizacaoController : ControllerBase
    {
        private readonly InStockContext _context;

        public MentalizacaoController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/Mentalizacao
        [HttpGet]
        public ActionResult<IEnumerable<Mentalizacao>> GetMentalizacoes()
        {
            return _context.Mentalizacaos.ToList();
        }

        // GET: api/Mentalizacao/5
        [HttpGet("{id}")]
        public ActionResult<Mentalizacao> GetMentalizacao(int id)
        {
            var mentalizacao = _context.Mentalizacaos.Find(id);

            if (mentalizacao == null)
            {
                return NotFound();
            }

            return mentalizacao;
        }

        // POST: api/Mentalizacao
        [HttpPost]
        public ActionResult<Mentalizacao> PostMentalizacao(Mentalizacao mentalizacao)
        {
            _context.Mentalizacaos.Add(mentalizacao);
            _context.SaveChanges();

            return CreatedAtAction("GetMentalizacao", new { id = mentalizacao.MentalizacaoId }, mentalizacao);
        }

        // PUT: api/Mentalizacao/5
        [HttpPut("{id}")]
        public IActionResult PutMentalizacao(int id, Mentalizacao mentalizacao)
        {
            if (id != mentalizacao.MentalizacaoId)
            {
                return BadRequest();
            }

            _context.Entry(mentalizacao).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Mentalizacao/5
        [HttpDelete("{id}")]
        public ActionResult<Mentalizacao> DeleteMentalizacao(int id)
        {
            var mentalizacao = _context.Mentalizacaos.Find(id);
            if (mentalizacao == null)
            {
                return NotFound();
            }

            _context.Mentalizacaos.Remove(mentalizacao);
            _context.SaveChanges();

            return mentalizacao;
        }
    }
}
