namespace Lab01_Ancco_Andre;

public class Auto<T>
{
    private string placa;
    private string sede;
    private T propietario;

    public Auto(string placa, string sede, T propietario)
    {
        this.placa = placa;
        this.sede = sede;
        this.propietario = propietario;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Placa: {placa}, Sede: {sede}");
        Console.WriteLine("Propietario:");
        // Asumimos que el propietario (Persona o Empresa) tiene su propio MostrarInformacion()
        if (propietario is Persona p) p.MostrarInformacion();
        else if (propietario is Empresa e) e.MostrarInformacion();
    }
}