using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class MuralSonho
{
    public int MuralId { get; set; }

    public int? UsuarioId { get; set; }

    public string? Titulo { get; set; }

    public string? Descricao { get; set; }

    public string? Imagem { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
