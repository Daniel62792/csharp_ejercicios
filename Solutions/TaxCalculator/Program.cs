using System;

namespace TaxCalculator
{
    class Program
    {
        private const double TAX_THRESHOLD = 12000;
        private const double TAX_RATE = 0.15;

        static void Main()
        {
            try
            {
                ExecuteTaxCalculator();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
                WaitForUser();
            }
        }

        static void ExecuteTaxCalculator()
        {
            DisplayHeader("Tax Calculator");
            
            double annualSalary = GetValidatedSalary();
            double taxAmount = CalculateTax(annualSalary);
            
            DisplayResult(annualSalary, taxAmount);
            WaitForUser();
        }

        static double GetValidatedSalary()
        {
            double salary;
            Console.Write("Ingrese su salario anual: $");
            
            while (!double.TryParse(Console.ReadLine(), out salary) || salary < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Salario inválido. Ingrese un número positivo: $");
                Console.ResetColor();
            }
            
            return salary;
        }

        static double CalculateTax(double annualSalary)
        {
            if (annualSalary <= TAX_THRESHOLD)
            {
                return 0;
            }
            
            double excess = annualSalary - TAX_THRESHOLD;
            return excess * TAX_RATE;
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

        static void DisplayResult(double salary, double tax)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RESULTADO:");
            Console.ResetColor();
            
            Console.WriteLine($"Salario anual: ${salary:F2}");
            Console.WriteLine($"Umbral de impuestos: ${TAX_THRESHOLD:F2}");
            Console.WriteLine($"Tasa de impuesto: {TAX_RATE:P0}");
            
            if (tax == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("No debe impuestos.");
            }
            else
            {
                double excess = salary - TAX_THRESHOLD;
                Console.WriteLine($"Excedente gravable: ${excess:F2}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Impuesto a pagar: ${tax:F2}");
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
