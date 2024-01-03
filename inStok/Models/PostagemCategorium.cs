using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class PostagemCategorium
{
    public int PostagemId { get; set; }

    public int CategoriaId { get; set; }

    public int PostagemCategoriaId { get; set; }

    public virtual Categorium Categoria { get; set; } = null!;

    public virtual Postagem Postagem { get; set; } = null!;
}
