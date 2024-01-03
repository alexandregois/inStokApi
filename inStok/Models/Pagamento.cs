using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class Pagamento
{
    public int PagamentoId { get; set; }

    public int? UsuarioId { get; set; }

    public int? TrilhaId { get; set; }

    public decimal? ValorPago { get; set; }

    public DateTime? DataPagamento { get; set; }

    public int? FormaPagamentoId { get; set; }

    public virtual FormaPagamento? FormaPagamento { get; set; }

    public virtual Trilha? Trilha { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
