using System;

namespace RootOrSquare
{
    class Program
    {
        static void Main()
        {
            try
            {
                ExecuteRootOrSquare();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
                WaitForUser();
            }
        }

        static void ExecuteRootOrSquare()
        {
            DisplayHeader("Root or Square Calculator");
            {
                double number = GetValidatedDouble("Ingrese un número:");
                double result = CalculateRootOrSquare(number);


                DisplayResult(number, result);
                WaitForUser();
            }
        }
        static double CalculateRootOrSquare(double number)
        {
            if (number > 0)
            {
                return Math.Sqrt(number);  // Raíz cuadrada
            }
            else if (number < 0)
            {
                return number * number;    // Cuadrado para negativos
            }
            else
            {
                return 0;                  // Cero permanece cero
            }
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

        static void DisplayResult(double input, double result)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RESULTADO:");
            Console.ResetColor();

            Console.WriteLine($"Número ingresado: {input}");

            string operation = input > 0 ? "RAÍZ CUADRADA" :
                             input < 0 ? "CUADRADO" : "CERO";
            Console.WriteLine($"Operación aplicada: {operation}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Resultado: {result:F4}");
            Console.ResetColor();
        }

        static void WaitForUser()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}

