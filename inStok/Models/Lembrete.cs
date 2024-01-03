using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class Lembrete
{
    public int LembreteId { get; set; }

    public int UsuarioId { get; set; }

    public string? Titulo { get; set; }

    public string? Descricao { get; set; }

    public DateTime? DataLembrete { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
