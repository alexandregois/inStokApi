using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class ImagemPostagem
{
    public int ImagemPostagemId { get; set; }

    public int PostagemId { get; set; }

    public byte[]? Imagem { get; set; }

    public virtual Postagem Postagem { get; set; } = null!;
}
