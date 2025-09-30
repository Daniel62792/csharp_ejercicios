using System;

namespace CirclePerimeter
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== CIRCLE PERIMETER CALCULATOR ===");
            Console.WriteLine();
            
            // Obtener radio
            double radius = GetValidatedDouble("Ingrese el radio del círculo: ");
            
            // Calcular perímetro
            double perimeter = 2 * Math.PI * radius;
            
            // Mostrar resultado
            DisplayResult(radius, perimeter);
            
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static double GetValidatedDouble(string prompt)
        {
            double result;
            Console.Write(prompt);
            
            while (!double.TryParse(Console.ReadLine(), out result) || result <= 0)
            {
                Console.Write("Radio inválido. Debe ser un número positivo:");
            }
            
            return result;
        }

        static void DisplayResult(double radius, double perimeter)
        {
            Console.WriteLine();
            Console.WriteLine("RESULTADO:");
            Console.WriteLine($"Radio del círculo: {radius}");
            Console.WriteLine($"Fórmula: 2 × π × radio");
            Console.WriteLine($"Valor de π: {Math.PI:F6}");
            Console.WriteLine($"Perímetro: {perimeter:F2}");
        }
    }
}
