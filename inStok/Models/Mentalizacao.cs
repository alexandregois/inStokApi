using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class Mentalizacao
{
    public int MentalizacaoId { get; set; }

    public int? UsuarioId { get; set; }

    public int? CategoriaId { get; set; }

    public string? Titulo { get; set; }

    public string? Descricao { get; set; }

    public DateTime DataCriacao { get; set; }

    public virtual Categorium? Categoria { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
