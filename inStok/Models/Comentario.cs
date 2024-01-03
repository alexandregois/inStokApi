using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class Comentario
{
    public int ComentarioId { get; set; }

    public int PostagemId { get; set; }

    public int UsuarioId { get; set; }

    public string? Texto { get; set; }

    public DateTime DataComentario { get; set; }

    public virtual Postagem Postagem { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
