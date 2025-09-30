using System;

namespace RemainderFinder
{
    class Program
    {
        static void Main()
        {
            try
            {
                ExecuteRemainderFinder();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
                Console.ResetColor();
                WaitForUser();
            }
        }

        static void ExecuteRemainderFinder()
        {
            DisplayHeader("Remainder Finder");
            
            Console.WriteLine("Ingrese dos números para calcular el residuo de la división:");
            double dividend = GetValidatedNumber("Dividendo (primer número): ");
            double divisor = GetValidatedDivisor();
            
            double remainder = CalculateRemainder(dividend, divisor);
            DisplayResult(dividend, divisor, remainder);
            WaitForUser();
        }

        static double GetValidatedNumber(string prompt)
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

        static double GetValidatedDivisor()
        {
            double divisor;
            Console.Write("Divisor (segundo número): ");
            
            while (!double.TryParse(Console.ReadLine(), out divisor) || divisor == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Divisor inválido. No puede ser cero. Ingrese otro número: ");
                Console.ResetColor();
            }
            
            return divisor;
        }

        static double CalculateRemainder(double dividend, double divisor)
        {
            return dividend % divisor;
        }

        static void DisplayHeader(string title)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('=', 50));
            Console.WriteLine(title.ToUpper());
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();
            Console.WriteLine();
        }

        static void DisplayResult(double dividend, double divisor, double remainder)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RESULTADO:");
            Console.ResetColor();
            
            Console.WriteLine("Dividendo: " + dividend);
            Console.WriteLine("Divisor: " + divisor);
            Console.WriteLine("Operación: " + dividend + " % " + divisor);
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            if (remainder == 0)
            {
                Console.WriteLine("Residuo: " + remainder + " (división exacta)");
            }
            else
            {
                Console.WriteLine("🔍 Residuo: " + remainder);
            }
            
            Console.ResetColor();
        }

        static void WaitForUser()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
