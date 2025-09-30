// See https://aka.ms/new-console-template for more information
using System;

class PositivePower
{
    static void Main()
    {
        Console.WriteLine("=== Positive Power Calculator ===");
        Console.Write("Ingrese un número: ");
        
        double number;
        if (double.TryParse(Console.ReadLine(), out number))
        {
            if (number > 0)
            {
                double result = number * number;
                Console.WriteLine($"Resultado: {result}");
            }
            else if (number < 0)
            {
                Console.WriteLine("Número negativo.");
            }
            else
            {
                Console.WriteLine("0");
            }
        }
        else
        {
            Console.WriteLine("Entrada no válida. Por favor ingrese un número.");
        }
        
        Console.WriteLine("Presione cualquier tecla para salir...");
        Console.ReadKey();
    }
}
