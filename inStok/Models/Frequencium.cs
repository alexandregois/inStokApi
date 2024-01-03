using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class Frequencium
{
    public int FrequenciaId { get; set; }

    public string? Titulo { get; set; }

    public int? Duracao { get; set; }

    public string? Audio { get; set; }

    public virtual ICollection<HistoricoFrequencium> HistoricoFrequencia { get; set; } = new List<HistoricoFrequencium>();
}
