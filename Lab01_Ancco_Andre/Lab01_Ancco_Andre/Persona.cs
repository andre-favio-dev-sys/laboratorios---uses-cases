namespace Lab01_Ancco_Andre;

class Persona
{
    private string nombre;
    private int edad;
    private int dni;

    public Persona(string nombre, int edad, int dni)
    {
        this.nombre = nombre;
        this.edad = edad;
        this.dni = dni;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {nombre}, Edad: {edad},  DNI: {dni}");
    }
}