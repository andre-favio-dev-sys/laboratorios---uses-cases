namespace Lab_02_Ancco_Andre.Models;

public class Auto
{
    public string Placa { get; set; }
    public string Sede { get; set; }
    public string TipoPropietario { get; set; } // "Persona" o "Empresa"
    public int PropietarioDni { get; set; }      // usado si TipoPropietario == "Persona"
    public int PropietarioEmpresaId { get; set; } // usado si TipoPropietario == "Empresa"

    public void MostrarInformacion()
    {
        Console.WriteLine($"Placa: {Placa}, Sede: {Sede}, TipoPropietario: {TipoPropietario}");
    }
}