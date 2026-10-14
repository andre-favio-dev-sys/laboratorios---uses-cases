using System;
using System.Collections.Generic;

namespace Lab03_Ancco_Andre.Models;

public partial class Producto
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public long? CategoriaId { get; set; }

    public DateTime? CreadoEn { get; set; }

    public virtual Categoria? Categoria { get; set; }
}
