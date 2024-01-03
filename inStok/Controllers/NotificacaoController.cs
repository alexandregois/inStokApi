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
    public class NotificacaoController : ControllerBase
    {
        private readonly InStockContext _context;

        public NotificacaoController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/Notificacao
        [HttpGet]
        [Route("/GetNotificacao/{usuarioId}")]
        [Authorize]
        public ActionResult<IEnumerable<Notificacao>> GetNotificacoes(int usuarioId)
        {
            return _context.Notificacaos.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        // GET: api/Notificacao/5
        [HttpGet("{id}")]
        public ActionResult<Notificacao> GetNotificacao(int id)
        {
            var notificacao = _context.Notificacaos.Find(id);

            if (notificacao == null)
            {
                return NotFound();
            }

            return notificacao;
        }

        // POST: api/Notificacao
        [HttpPost]
        public ActionResult<Notificacao> PostNotificacao(Notificacao notificacao)
        {
            _context.Notificacaos.Add(notificacao);
            _context.SaveChanges();

            return CreatedAtAction("GetNotificacao", new { id = notificacao.NotificacaoId }, notificacao);
        }

        // PUT: api/Notificacao/5
        [HttpPut("{id}")]
        public IActionResult PutNotificacao(int id, Notificacao notificacao)
        {
            if (id != notificacao.NotificacaoId)
            {
                return BadRequest();
            }

            _context.Entry(notificacao).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Notificacao/5
        [HttpDelete("{id}")]
        public ActionResult<Notificacao> DeleteNotificacao(int id)
        {
            var notificacao = _context.Notificacaos.Find(id);
            if (notificacao == null)
            {
                return NotFound();
            }

            _context.Notificacaos.Remove(notificacao);
            _context.SaveChanges();

            return notificacao;
        }
    }
}
