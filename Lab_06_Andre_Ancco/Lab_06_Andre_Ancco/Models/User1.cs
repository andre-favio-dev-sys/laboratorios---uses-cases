using System;
using System.Collections.Generic;

namespace Lab_06_Andre_Ancco.Models;

public partial class User1
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;
}
