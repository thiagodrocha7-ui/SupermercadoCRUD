using System;
using System.Collections.Generic;

namespace SupermercadoCrud.Models;

public partial class Compra
{
    public int CodigoCompra { get; set; }

    public DateTime DataCompra { get; set; }

    public decimal ValorTotal { get; set; }

    public string TipoPagamento { get; set; } = null!;

    public int? CodigoCliente { get; set; }

    public virtual Cliente? CodigoClienteNavigation { get; set; }
}
