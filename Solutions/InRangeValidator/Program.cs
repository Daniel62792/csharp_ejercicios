using System;

namespace InRangeValidator
{
    class Program
    {
        private const int MIN_RANGE = 10;
        private const int MAX_RANGE = 20;

        static void Main()
        {
            try
            {
                ExecuteInRangeValidator();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
                WaitForUser();
            }
        }

        static void ExecuteInRangeValidator()
        {
            DisplayHeader("InRange Validator");
            
            int number = GetValidatedNumber();
            bool isInRange = CheckInRange(number);
            
            DisplayResult(number, isInRange);
            WaitForUser();
        }

        static int GetValidatedNumber()
        {
            int number;
            Console.Write($"Ingrese un número para verificar si está entre {MIN_RANGE} y {MAX_RANGE}: ");
            
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Número inválido. Ingrese un número entero: ");
                Console.ResetColor();
            }
            
            return number;
        }

        static bool CheckInRange(int number)
        {
            return number >= MIN_RANGE && number <= MAX_RANGE;
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

        static void DisplayResult(int number, bool isInRange)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RESULTADO:");
            Console.ResetColor();
            
            Console.WriteLine($"Número ingresado: {number}");
            Console.WriteLine($"Rango verificado: {MIN_RANGE} a {MAX_RANGE} (ambos incluidos)");
            
            Console.WriteLine();
            
            if (isInRange)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Está en el rango.");
                Console.ResetColor();
                
                // Mostrar información de posición
                int distanceFromMin = number - MIN_RANGE;
                int distanceFromMax = MAX_RANGE - number;
                
                Console.WriteLine($"   • {distanceFromMin} números después del mínimo ({MIN_RANGE})");
                Console.WriteLine($"   • {distanceFromMax} números antes del máximo ({MAX_RANGE})");
                
                if (number == MIN_RANGE)
                    Console.WriteLine("   • Es el valor mínimo del rango");
                else if (number == MAX_RANGE)
                    Console.WriteLine("   • Es el valor máximo del rango");
                else if (number == (MIN_RANGE + MAX_RANGE) / 2)
                    Console.WriteLine("   • Está en el punto medio del rango");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fuera del rango.");
                Console.ResetColor();
                
                if (number < MIN_RANGE)
                {
                    int difference = MIN_RANGE - number;
                    Console.WriteLine($"   • {difference} número(s) por debajo del mínimo");
                }
                else
                {
                    int difference = number - MAX_RANGE;
                    Console.WriteLine($"   • {difference} número(s) por encima del máximo");
                }
            }
            
            // Estadísticas del rango
            Console.WriteLine();
            Console.WriteLine("Información del rango:");
            Console.WriteLine($"   • Total de números en el rango: {MAX_RANGE - MIN_RANGE + 1}");
            Console.WriteLine($"   • Punto medio: {(MIN_RANGE + MAX_RANGE) / 2}");
            Console.WriteLine($"   • Rango completo: {MIN_RANGE} → {MAX_RANGE}");
        }

        static void WaitForUser()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
