using System;
using System.Collections.Generic;

namespace Lab03_Ancco_Andre.Models;

/// <summary>
/// Auth: Manages updates to the auth system.
/// </summary>
public partial class SchemaMigration
{
    public string Version { get; set; } = null!;
}
