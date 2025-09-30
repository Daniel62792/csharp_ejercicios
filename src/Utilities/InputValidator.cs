using System;

namespace DoubleOrTriple
{
    class Program
    {
        static void Main()
        {
            try
            {
                ExecuteDoubleOrTriple();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ Error: {ex.Message}");
                Console.ResetColor();
                WaitForUser();
            }
        }

        static void ExecuteDoubleOrTriple()
        {
            DisplayHeader("Double or Triple Calculator");
            
            double firstNumber = GetValidatedDouble("Ingrese el primer número: ");
            double secondNumber = GetValidatedDouble("Ingrese el segundo número: ");
            
            double result = CalculateDoubleOrTriple(firstNumber, secondNumber);
            DisplayCalculation(firstNumber, secondNumber, result);
            
            WaitForUser();
        }

        static double GetValidatedDouble(string prompt)
        {
            double result;
            Console.Write(prompt);
            
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Entrada inválida. Por favor ingrese un número: ");
                Console.ResetColor();
            }
            
            return result;
        }

        static void DisplayHeader(string title)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"🎯 {title.ToUpper()}");
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();
            Console.WriteLine();
        }

        static void WaitForUser()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static double CalculateDoubleOrTriple(double first, double second)
        {
            return first > second ? first * 2 : second * 3;
        }

        static void DisplayCalculation(double first, double second, double result)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("📊 RESULTADO:");
            Console.ResetColor();
            
            Console.WriteLine($"Número 1: {first}");
            Console.WriteLine($"Número 2: {second}");
            
            string operation = first > second ? "DOBLE del primero" : "TRIPLE del segundo";
            Console.WriteLine($"Operación: {operation}");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"🎯 Resultado: {result}");
            Console.ResetColor();
        }
    }
}            WaitForUser();
        }

        static double GetValidatedDouble(string prompt)
        {
            double result;
            Console.Write(prompt);
            
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Entrada inválida. Por favor ingrese un número: ");
                Console.ResetColor();
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

        static void WaitForUser()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static double CalculateDoubleOrTriple(double first, double second)
        {
            return first > second ? first * 2 : second * 3;
        }

        static void DisplayCalculation(double first, double second, double result)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RESULTADO:");
            Console.ResetColor();
            
            Console.WriteLine($"Número 1: {first}");
            Console.WriteLine($"Número 2: {second}");
            
            string operation = first > second ? "DOBLE del primero" : "TRIPLE del segundo";
            Console.WriteLine($"Operación: {operation}");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Resultado: {result}");
            Console.ResetColor();
        }
    }
}