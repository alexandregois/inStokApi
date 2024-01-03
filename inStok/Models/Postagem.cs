using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class Postagem
{
    public int PostagemId { get; set; }

    public int UsuarioId { get; set; }

    public string? Conteudo { get; set; }

    public DateTime DataPublicacao { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<ImagemPostagem> ImagemPostagems { get; set; } = new List<ImagemPostagem>();

    public virtual ICollection<Imagem> Imagems { get; set; } = new List<Imagem>();

    public virtual ICollection<PostagemCategorium> PostagemCategoria { get; set; } = new List<PostagemCategorium>();

    public virtual Usuario Usuario { get; set; } = null!;
}
