using System;
using System.Collections.Generic;

namespace Lab_06_Andre_Ancco.Models;

public partial class SchemaMigration1
{
    public long Version { get; set; }

    public DateTime? InsertedAt { get; set; }
}
