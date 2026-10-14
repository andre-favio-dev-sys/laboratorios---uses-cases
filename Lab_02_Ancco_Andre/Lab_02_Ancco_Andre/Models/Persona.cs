namespace Lab_02_Ancco_Andre.Models;

public class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public int Dni { get; set; }
    public string Email { get; set; }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}, Edad: {Edad}, DNI: {Dni}, Email: {Email}");
    }
}