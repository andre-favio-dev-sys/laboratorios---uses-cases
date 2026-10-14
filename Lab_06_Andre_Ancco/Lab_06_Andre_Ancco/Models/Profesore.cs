using System;
using System.Collections.Generic;

namespace Lab_06_Andre_Ancco.Models;

public partial class Profesore
{
    public int IdProfesor { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Especialidad { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
