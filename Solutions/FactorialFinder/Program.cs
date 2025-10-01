using System;

namespace FactorialFinder
{
    class Program
    {
        static void Main()
        {
            try
            {
                ExecuteFactorialFinder();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
                WaitForUser();
            }
        }

        static void ExecuteFactorialFinder()
        {
            DisplayHeader("Factorial Finder");
            
            int number = GetValidatedNumber();
            long factorial = CalculateFactorial(number);
            
            DisplayResult(number, factorial);
            WaitForUser();
        }

        static int GetValidatedNumber()
        {
            int number;
            Console.Write("Ingrese un número para calcular su factorial: ");
            
            while (!int.TryParse(Console.ReadLine(), out number) || number < 0 || number > 20)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Número inválido. Ingrese un número entre 0 y 20: ");
                Console.ResetColor();
            }
            
            return number;
        }

        static long CalculateFactorial(int number)
        {
            if (number == 0 || number == 1)
                return 1;
            
            long result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }
            return result;
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

        static void DisplayResult(int number, long factorial)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RESULTADO:");
            Console.ResetColor();
            
            Console.WriteLine($"Número ingresado: {number}");
            Console.WriteLine($"Operación: {number}!");
            
            // Mostrar la progresión del cálculo
            Console.Write($"Progresión: ");
            for (int i = 1; i <= number; i++)
            {
                Console.Write(i);
                if (i < number)
                    Console.Write(" × ");
            }
            Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Factorial: {factorial:N0}");
            Console.ResetColor();
            
            // Información adicional
            Console.WriteLine();
            Console.WriteLine("Información:");
            Console.WriteLine($"   • 0! = 1 (por definición)");
            Console.WriteLine($"   • 1! = 1");
            Console.WriteLine($"   • 5! = 120");
            Console.WriteLine($"   • 10! = 3,628,800");
            Console.WriteLine($"   • 20! = 2,432,902,008,176,640,000");
            
            if (number > 12)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Números mayores a 12! pueden causar overflow en int32");
                Console.ResetColor();
            }
        }

        static void WaitForUser()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
