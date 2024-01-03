using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class Notificacao
{
    public int NotificacaoId { get; set; }

    public int UsuarioId { get; set; }

    public string? Mensagem { get; set; }

    public DateTime DataNotificacao { get; set; }

    public bool Lida { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
