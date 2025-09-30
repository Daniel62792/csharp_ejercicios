using System;

namespace FractionDifference
{
    class Program
    {
        static void Main()
        {
            try
            {
                ExecuteFractionDifference();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
                WaitForUser();
            }
        }

        static void ExecuteFractionDifference()
        {
            DisplayHeader("Fraction Difference Calculator");
            
            Console.WriteLine("Ingrese la primera fracción:");
            var fraction1 = GetFraction();
            
            Console.WriteLine("\nIngrese la segunda fracción:");
            var fraction2 = GetFraction();
            
            var result = CalculateDifference(fraction1, fraction2);
            DisplayResult(fraction1, fraction2, result);
            WaitForUser();
        }

        static (int numerator, int denominator) GetFraction()
        {
            int numerator = GetValidatedInt("  Numerador: ");
            int denominator = GetValidatedDenominator("  Denominador: ");
            return (numerator, denominator);
        }

        static int GetValidatedInt(string prompt)
        {
            int result;
            Console.Write(prompt);
            
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Número inválido. Ingrese un número entero: ");
                Console.ResetColor();
            }
            
            return result;
        }

        static int GetValidatedDenominator(string prompt)
        {
            int denominator;
            Console.Write(prompt);
            
            while (!int.TryParse(Console.ReadLine(), out denominator) || denominator == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Denominador inválido. No puede ser cero: ");
                Console.ResetColor();
            }
            
            return denominator;
        }

        static (int numerator, int denominator) CalculateDifference(
            (int num, int den) frac1, (int num, int den) frac2)
        {
            // Encontrar común denominador
            int commonDenominator = frac1.den * frac2.den;
            
            // Calcular numeradores equivalentes
            int num1 = frac1.num * frac2.den;
            int num2 = frac2.num * frac1.den;
            
            // Calcular diferencia
            int resultNumerator = num1 - num2;
            
            // Simplificar la fracción
            return SimplifyFraction(resultNumerator, commonDenominator);
        }

        static (int numerator, int denominator) SimplifyFraction(int numerator, int denominator)
        {
            if (numerator == 0)
                return (0, 1);
                
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            return (numerator / gcd, denominator / gcd);
        }

        static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
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

        static void DisplayResult(
            (int num, int den) frac1, 
            (int num, int den) frac2, 
            (int num, int den) result)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RESULTADO:");
            Console.ResetColor();
            
            Console.WriteLine($"Primera fracción: {frac1.num}/{frac1.den}");
            Console.WriteLine($"Segunda fracción: {frac2.num}/{frac2.den}");
            Console.WriteLine($"Operación: {frac1.num}/{frac1.den} - {frac2.num}/{frac2.den}");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            if (result.num == 0)
            {
                Console.WriteLine($"Diferencia: {result.num}");
            }
            else if (result.den == 1)
            {
                Console.WriteLine($"Diferencia: {result.num}");
            }
            else
            {
                Console.WriteLine($"Diferencia: {result.num}/{result.den}");
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
