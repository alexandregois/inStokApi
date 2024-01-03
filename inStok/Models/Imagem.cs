using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class Imagem
{
    public int ImagemId { get; set; }

    public int? PostagemId { get; set; }

    public byte[]? Imagem1 { get; set; }

    public virtual Postagem? Postagem { get; set; }
}
