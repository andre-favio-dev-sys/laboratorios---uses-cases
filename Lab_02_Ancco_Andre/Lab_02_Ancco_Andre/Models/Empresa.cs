namespace Lab_02_Ancco_Andre.Models;

public class Empresa
{
    public int Id { get; set; }
    public string RazonSocial { get; set; }
    public string Ruc { get; set; }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Id: {Id}, Razón Social: {RazonSocial}, RUC: {Ruc}");
    }
}