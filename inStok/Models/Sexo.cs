using System;
using System.Collections.Generic;

namespace inStok.Models;

public partial class Sexo
{
    public int SexoId { get; set; }

    public string? NomeSexo { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
