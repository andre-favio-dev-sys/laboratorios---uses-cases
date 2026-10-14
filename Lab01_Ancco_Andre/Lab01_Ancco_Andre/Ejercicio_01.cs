namespace Lab01_Ancco_Andre;

public class Ejercicio01
{
    public void Saludar()
    {
        Console.WriteLine("¡Hola! Bienvenido a la sesión práctica de C#");
    }

    public int Sumar(int a, int b)
    {
        return a + b;
    }

    public int Resta(int a, int b)
    {
        return a - b;
    }

    public int Multiplicacion(int a, int b)
    {
        return a * b;
    }

    public double Division(int a, int b)
    {
        if (b == 0)
        {
            Console.WriteLine("Error: no se puede dividir entre cero.");
            return 0;
        }
        return (double)a / b;
    }
}