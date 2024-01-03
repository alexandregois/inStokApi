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
    public class PagamentoController : ControllerBase
    {
        private readonly InStockContext _context;

        public PagamentoController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/Pagamento
        [HttpGet]
        public ActionResult<IEnumerable<Pagamento>> GetPagamentos()
        {
            return _context.Pagamentos.ToList();
        }

        // GET: api/Pagamento/5
        [HttpGet("{id}")]
        public ActionResult<Pagamento> GetPagamento(int id)
        {
            var pagamento = _context.Pagamentos.Find(id);

            if (pagamento == null)
            {
                return NotFound();
            }

            return pagamento;
        }

        // POST: api/Pagamento
        [HttpPost]
        public ActionResult<Pagamento> PostPagamento(Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);
            _context.SaveChanges();

            return CreatedAtAction("GetPagamento", new { id = pagamento.PagamentoId }, pagamento);
        }

        // PUT: api/Pagamento/5
        [HttpPut("{id}")]
        public IActionResult PutPagamento(int id, Pagamento pagamento)
        {
            if (id != pagamento.PagamentoId)
            {
                return BadRequest();
            }

            _context.Entry(pagamento).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Pagamento/5
        [HttpDelete("{id}")]
        public ActionResult<Pagamento> DeletePagamento(int id)
        {
            var pagamento = _context.Pagamentos.Find(id);
            if (pagamento == null)
            {
                return NotFound();
            }

            _context.Pagamentos.Remove(pagamento);
            _context.SaveChanges();

            return pagamento;
        }
    }
}
