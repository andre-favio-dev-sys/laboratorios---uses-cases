namespace Lab01_Ancco_Andre;

public class EjercicioSaludo
{
    public void Ejecutar()
    {
        Saludar();
        int resultado = Sumar(5, 10);
        Console.WriteLine("El resultado de la suma es: " + resultado);
    }

    void Saludar()
    {
        Console.WriteLine("¡Hola! Bienvenido a la sesión práctica de C#");
    }

    int Sumar(int a, int b)
    {
        return a + b;
    }
}