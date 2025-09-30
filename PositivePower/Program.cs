using System;
using Utilities;

namespace PositivePower
{
    class Program
    {
        static void Main()
        {
            try
            {
                ExecutePositivePower();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ExecutePositivePower()
        {
            Console.WriteLine("=== CALCULADORA DE POTENCIA POSITIVA ===");
            
            double number = InputValidator.GetValidatedDouble("Ingrese un número: ");
            double result = CalculatePositivePower(number);
            
            DisplayResult(number, result);
        }

        static double CalculatePositivePower(double number)
        {
            if (number > 0) return number * number;
            if (number < 0) throw new InvalidOperationException("Número negativo.");
            return 0;
        }

        static void DisplayResult(double input, double result)
        {
            Console.WriteLine($"Entrada: {input} → Resultado: {result}");
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}