using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class Aula
{
    public int AulaId { get; set; }

    public int? ModuloId { get; set; }

    public string? Titulo { get; set; }

    public string? Conteudo { get; set; }

    public virtual ICollection<HistoricoAula> HistoricoAulas { get; set; } = new List<HistoricoAula>();

    public virtual Modulo? Modulo { get; set; }
}
