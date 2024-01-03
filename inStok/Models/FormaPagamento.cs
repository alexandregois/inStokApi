using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class FormaPagamento
{
    public int FormaPagamentoId { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}
