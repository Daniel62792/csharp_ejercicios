using System;
using System.Linq;

namespace SmallestOfFive
{
    class Program
    {
        static void Main()
        {
            try
            {
                ExecuteSmallestOfFive();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
                WaitForUser();
            }
        }

        static void ExecuteSmallestOfFive()
        {
            DisplayHeader("Smallest of Five Finder");
            
            double[] numbers = GetFiveNumbers();
            double smallest = FindSmallestNumber(numbers);
            
            DisplayResult(numbers, smallest);
            WaitForUser();
        }

        static double[] GetFiveNumbers()
        {
            double[] numbers = new double[5];
            string[] ordinals = { "primero", "segundo", "tercero", "cuarto", "quinto" };
            
            Console.WriteLine("Ingrese cinco números:");
            
            for (int i = 0; i < 5; i++)
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

        static double FindSmallestNumber(double[] numbers)
        {
            // Método 1: Usando LINQ
            return numbers.Min();
            
            // Método alternativo: Usando algoritmo manual
            // double smallest = numbers[0];
            // for (int i = 1; i < numbers.Length; i++)
            // {
            //     if (numbers[i] < smallest)
            //         smallest = numbers[i];
            // }
            // return smallest;
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

        static void DisplayResult(double[] numbers, double smallest)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RESULTADO:");
            Console.ResetColor();
            
            Console.WriteLine($"Números ingresados: {string.Join(", ", numbers)}");
            Console.WriteLine($"Cantidad de números: {numbers.Length}");
            
            // Encontrar la posición del número más pequeño
            int smallestIndex = Array.IndexOf(numbers, smallest) + 1;
            string[] positions = { "primero", "segundo", "tercero", "cuarto", "quinto" };
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Número más pequeño: {smallest}");
            Console.ResetColor();
            
            Console.WriteLine($"   • Posición: {smallestIndex}° ({positions[smallestIndex - 1]})");
            Console.WriteLine($"   • Valor: {smallest}");
            
            // Análisis adicional
            Console.WriteLine();
            Console.WriteLine("Análisis adicional:");
            Console.WriteLine($"   • Número más grande: {numbers.Max()}");
            Console.WriteLine($"   • Rango total: {numbers.Max() - smallest:F2}");
            Console.WriteLine($"   • Promedio: {numbers.Average():F2}");
            
            // Mostrar números ordenados
            var sortedNumbers = numbers.OrderBy(n => n).ToArray();
            Console.WriteLine($"   • Orden ascendente: {string.Join(" < ", sortedNumbers)}");
            
            // Contar números menores que el promedio
            double average = numbers.Average();
            int belowAverage = numbers.Count(n => n < average);
            Console.WriteLine($"   • Números bajo el promedio: {belowAverage}");
        }

        static void WaitForUser()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
