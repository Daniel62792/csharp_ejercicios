using System;

namespace SumOfEvens
{
    class Program
    {
        static void Main()
        {
            try
            {
                ExecuteSumOfEvens();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
                WaitForUser();
            }
        }

        static void ExecuteSumOfEvens()
        {
            DisplayHeader("Sum of Evens Calculator");
            
            int sum = CalculateSumOfEvens();
            DisplayResult(sum);
            WaitForUser();
        }

        static int CalculateSumOfEvens()
        {
            int sum = 0;
            Console.WriteLine("Calculando la suma de números pares entre 1 y 50...");
            Console.WriteLine();
            
            for (int i = 1; i <= 50; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                    
                    // Mostrar progreso
                    if (i < 50)
                    {
                        Console.Write($"{i} + ");
                    }
                    else
                    {
                        Console.Write($"{i}");
                    }
                }
            }
            
            Console.WriteLine();
            return sum;
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

        static void DisplayResult(int sum)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RESULTADO:");
            Console.ResetColor();
            
            Console.WriteLine($"Rango: números pares entre 1 y 50");
            Console.WriteLine($"Total de números pares: 25");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Suma total: {sum}");
            Console.ResetColor();
            
            Console.WriteLine();
            Console.WriteLine($"Progresión: 2 + 4 + 6 + ... + 48 + 50");
            Console.WriteLine($"Fórmula: n(n+1) donde n=25 → 25×26 = {25 * 26}");
        }

        static void WaitForUser()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}