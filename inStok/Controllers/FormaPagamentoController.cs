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
    public class FormaPagamentoController : ControllerBase
    {
        private readonly InStockContext _context;

        public FormaPagamentoController(InStockContext context)
        {
            _context = context;
        }

        // GET: api/FormaPagamento
        [HttpGet]
        public ActionResult<IEnumerable<FormaPagamento>> GetFormasPagamento()
        {
            return _context.FormaPagamentos.ToList();
        }

        // GET: api/FormaPagamento/5
        [HttpGet("{id}")]
        public ActionResult<FormaPagamento> GetFormaPagamento(int id)
        {
            var formaPagamento = _context.FormaPagamentos.Find(id);

            if (formaPagamento == null)
            {
                return NotFound();
            }

            return formaPagamento;
        }

        // POST: api/FormaPagamento
        [HttpPost]
        public ActionResult<FormaPagamento> PostFormaPagamento(FormaPagamento formaPagamento)
        {
            _context.FormaPagamentos.Add(formaPagamento);
            _context.SaveChanges();

            return CreatedAtAction("GetFormaPagamento", new { id = formaPagamento.FormaPagamentoId }, formaPagamento);
        }

        // PUT: api/FormaPagamento/5
        [HttpPut("{id}")]
        public IActionResult PutFormaPagamento(int id, FormaPagamento formaPagamento)
        {
            if (id != formaPagamento.FormaPagamentoId)
            {
                return BadRequest();
            }

            _context.Entry(formaPagamento).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/FormaPagamento/5
        [HttpDelete("{id}")]
        public ActionResult<FormaPagamento> DeleteFormaPagamento(int id)
        {
            var formaPagamento = _context.FormaPagamentos.Find(id);
            if (formaPagamento == null)
            {
                return NotFound();
            }

            _context.FormaPagamentos.Remove(formaPagamento);
            _context.SaveChanges();

            return formaPagamento;
        }
    }
}
