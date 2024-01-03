using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class Trilha
{
    public int TrilhaId { get; set; }

    public string? Nome { get; set; }

    public string? Descricao { get; set; }

    public bool? Egratuita { get; set; }

    public decimal? Valor { get; set; }

    public int? CategoriaTrilhaId { get; set; }

    public virtual ICollection<Modulo> Modulos { get; set; } = new List<Modulo>();

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}
