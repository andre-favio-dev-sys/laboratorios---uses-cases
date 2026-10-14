using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab05_Ancco_Andre.Models;

public partial class Curso
{
    public int IdCurso { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int Creditos { get; set; }

    public virtual ICollection<Asistencia> Asistencia { get; set; }
        = new List<Asistencia>();

    public virtual ICollection<Evaluacione> Evaluaciones { get; set; }
        = new List<Evaluacione>();

    public virtual ICollection<Materia> Materia { get; set; }
        = new List<Materia>();

    public virtual ICollection<Matricula> Matriculas { get; set; }
        = new List<Matricula>();

    [Column("id_profesor")]
    public int? IdProfesor { get; set; }

    [ForeignKey(nameof(IdProfesor))]
    public virtual Profesore? IdProfesorNavigation { get; set; }
}