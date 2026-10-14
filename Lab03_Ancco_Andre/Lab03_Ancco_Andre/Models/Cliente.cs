using System;
using System.Collections.Generic;

namespace Lab03_Ancco_Andre.Models;

public partial class Cliente
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime? CreadoEn { get; set; }
}
