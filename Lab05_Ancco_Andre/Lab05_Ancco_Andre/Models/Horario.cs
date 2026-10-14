namespace Lab05_Ancco_Andre.Models;

public class Horario
{
    public int IdHorario { get; set; }

    public string Dia { get; set; } = null!;

    public string HoraInicio { get; set; } = null!;

    public string HoraFin { get; set; } = null!;
}
