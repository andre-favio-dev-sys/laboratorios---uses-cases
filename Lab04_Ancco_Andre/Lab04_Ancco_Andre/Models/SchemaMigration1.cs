using System;
using System.Collections.Generic;

namespace Lab04_Ancco_Andre.Models;

public partial class SchemaMigration1
{
    public long Version { get; set; }

    public DateTime? InsertedAt { get; set; }
}
