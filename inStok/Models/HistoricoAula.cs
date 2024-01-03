using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class HistoricoAula
{
    public int HistoricoId { get; set; }

    public int? UsuarioId { get; set; }

    public int? AulaId { get; set; }

    public DateTime DataVisualizacao { get; set; }

    public int HistoricoAulaId { get; set; }

    public virtual Aula? Aula { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
