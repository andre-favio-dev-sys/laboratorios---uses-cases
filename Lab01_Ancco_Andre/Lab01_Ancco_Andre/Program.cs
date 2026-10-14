using Lab01_Ancco_Andre;

var test = new Ejercicio01();
test.Saludar();

int resultadoS = test.Sumar(5, 10);
int resultadoR = test.Resta(5, 10);
int resultadoM = test.Multiplicacion(5, 10);
double resultadoD = test.Division(5, 10);

Console.WriteLine("\n--- Ejercicio 01 ---");
Console.WriteLine("El resultado de la Suma es: " + resultadoS);
Console.WriteLine("El resultado de la Resta es: " + resultadoR);
Console.WriteLine("El resultado de la Multiplicación es: " + resultadoM);
Console.WriteLine("El resultado de la División es: " + resultadoD);

// Ejercicio 02
var test2 = new Ejercicio02();
Console.WriteLine("\n--- Ejercicio 02 ---");
test2.ImprimirPrimos();

// Ejercicio 03
var test3 = new Ejercicio03();

var celsius = Ejercicio03.FahrenheitACelsius(100);
var fahrenheit = Ejercicio03.CelsiusAFahrenheit(37);

Console.WriteLine("\n--- Ejercicio 03 ---");
Console.WriteLine("100°F equivalen a: " + celsius + "°C");
Console.WriteLine("37°C equivalen a: " + fahrenheit + "°F");

// Persona (POO - Encapsulamiento)
var persona1 = new Persona("Andre", 21, dni:75007269);
Console.WriteLine("\n--- Persona (POO) ---");
persona1.MostrarInformacion();

// Auto (Genéricos)
Console.WriteLine("\n--- Auto con Propietario Persona ---");
var autoConPersona = new Auto<Persona>("ABC-123", "Sede Central", persona1);
autoConPersona.MostrarInformacion();

Console.WriteLine("\n--- Auto con Propietario Empresa ---");
var empresa1 = new Empresa(1, "Tecsup SAC", "20123456789");
var autoConEmpresa = new Auto<Empresa>("XYZ-789", "Sede Norte", empresa1);
autoConEmpresa.MostrarInformacion();

