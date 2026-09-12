using System;
using System.Collections.Generic;

namespace SupermercadoCrud.Models;

public partial class Cliente
{
    public int Codigo { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Statuss { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
