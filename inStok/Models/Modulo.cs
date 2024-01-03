using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class Modulo
{
    public int ModuloId { get; set; }

    public int? TrilhaId { get; set; }

    public string? Nome { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<Aula> Aulas { get; set; } = new List<Aula>();

    public virtual Trilha? Trilha { get; set; }
}
