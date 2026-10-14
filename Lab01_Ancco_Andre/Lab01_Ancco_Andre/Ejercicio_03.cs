namespace Lab01_Ancco_Andre;

public class Ejercicio03
{
    // C = 5(F - 32) / 9
    public static double FahrenheitACelsius(double f)
    {
        return 5 * (f - 32) / 9;
    }

    // F = (9C / 5) + 32
    public static double CelsiusAFahrenheit(double c)
    {
        return (9 * c / 5) + 32;
    }
}