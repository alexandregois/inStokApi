using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class Anuncio
{
    public int AnuncioId { get; set; }

    public string? Titulo { get; set; }

    public string? Descricao { get; set; }

    public byte[]? Imagem { get; set; }
}
