namespace Lab01_Ancco_Andre;

public class Ejercicio02
{
    public void ImprimirPrimos()
    {
        Console.WriteLine("Los 10 primeros números primos son:");
        int contador = 0;
        int numero = 2;

        while (contador < 10)
        {
            if (EsPrimo(numero))
            {
                Console.Write(numero + " ");
                contador++;
            }
            numero++;
        }
        Console.WriteLine();
    }

    bool EsPrimo(int numero)
    {
        if (numero < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(numero); i++)
        {
            if (numero % i == 0)
                return false;
        }
        return true;
    }
}