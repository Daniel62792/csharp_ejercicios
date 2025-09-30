using System;
using System.Linq;

namespace AverageOfFour
{
    class Program
    {
        static void Main()
        {
            try
            {
                ExecuteAverageOfFour();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
                WaitForUser();
            }
        }

        static void ExecuteAverageOfFour()
        {
            DisplayHeader("Average of Four Calculator");
            
            double[] numbers = GetFourNumbers();
            double average = CalculateAverage(numbers);
            
            DisplayResult(numbers, average);
            WaitForUser();
        }

        static double[] GetFourNumbers()
        {
            double[] numbers = new double[4];
            string[] ordinals = { "primero", "segundo", "tercero", "cuarto" };
            
            Console.WriteLine("Ingrese cuatro números:");
            
            for (int i = 0; i < 4; i++)
            {
                numbers[i] = GetValidatedDouble($"  {ordinals[i]} número: ");
            }
            
            return numbers;
        }

        static double GetValidatedDouble(string prompt)
        {
            double result;
            Console.Write(prompt);
            
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Número inválido. Ingrese un número válido: ");
                Console.ResetColor();
            }
            
            return result;
        }

        static double CalculateAverage(double[] numbers)
        {
            return numbers.Average();
        }

        static void DisplayHeader(string title)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"{title.ToUpper()}");
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();
            Console.WriteLine();
        }

        static void DisplayResult(double[] numbers, double average)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RESULTADO:");
            Console.ResetColor();
            
            Console.WriteLine($"Números ingresados: {string.Join(", ", numbers)}");
            Console.WriteLine($"Cantidad de números: {numbers.Length}");
            
            // Mostrar la suma intermedia
            double sum = numbers.Sum();
            Console.WriteLine($"Suma total: {sum}");
            
            // Mostrar la fórmula
            Console.WriteLine($"Fórmula: ({string.Join(" + ", numbers)}) / {numbers.Length}");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            if (average == Math.Truncate(average))
            {
                Console.WriteLine($"Promedio: {average:F0} (número entero)");
            }
            else
            {
                Console.WriteLine($"Promedio: {average:F2} (número decimal)");
            }
            
            Console.ResetColor();
            
            // Análisis adicional
            Console.WriteLine();
            Console.WriteLine("Análisis adicional:");
            Console.WriteLine($"   • Número más alto: {numbers.Max()}");
            Console.WriteLine($"   • Número más bajo: {numbers.Min()}");
            Console.WriteLine($"   • Rango: {numbers.Max() - numbers.Min():F2}");
        }

        static void WaitForUser()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
