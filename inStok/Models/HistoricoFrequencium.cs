using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class HistoricoFrequencium
{
    public int HistoricoId { get; set; }

    public int? UsuarioId { get; set; }

    public int? FrequenciaId { get; set; }

    public DateTime DataOuvida { get; set; }

    public int HistoricoFrequanciaId { get; set; }

    public virtual Frequencium? Frequencia { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
