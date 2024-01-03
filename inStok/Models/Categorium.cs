using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class Categorium
{
    public int CategoriaId { get; set; }

    public string? Nome { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<Mentalizacao> Mentalizacaos { get; set; } = new List<Mentalizacao>();

    public virtual ICollection<PostagemCategorium> PostagemCategoria { get; set; } = new List<PostagemCategorium>();
}
