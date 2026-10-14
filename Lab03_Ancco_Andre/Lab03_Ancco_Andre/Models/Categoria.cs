using System;
using System.Collections.Generic;

namespace Lab03_Ancco_Andre.Models;

public partial class Categoria
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime? CreadoEn { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
