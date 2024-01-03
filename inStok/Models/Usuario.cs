using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public string? Senha { get; set; }

    public DateTime? DataNascimento { get; set; }

    public byte[]? FotoPerfil { get; set; }

    public int? SexoId { get; set; }

    public string? Apelido { get; set; }

    public string? Sobrenome { get; set; }

    public string? Telefone { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<HistoricoAula> HistoricoAulas { get; set; } = new List<HistoricoAula>();

    public virtual ICollection<HistoricoFrequencium> HistoricoFrequencia { get; set; } = new List<HistoricoFrequencium>();

    public virtual ICollection<Lembrete> Lembretes { get; set; } = new List<Lembrete>();

    public virtual ICollection<Mentalizacao> Mentalizacaos { get; set; } = new List<Mentalizacao>();

    public virtual ICollection<MuralSonho> MuralSonhos { get; set; } = new List<MuralSonho>();

    public virtual ICollection<Notificacao> Notificacaos { get; set; } = new List<Notificacao>();

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();

    public virtual ICollection<Postagem> Postagems { get; set; } = new List<Postagem>();

    public virtual Sexo? Sexo { get; set; }
}
