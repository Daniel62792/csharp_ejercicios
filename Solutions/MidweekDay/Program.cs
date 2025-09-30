using System;

namespace MidweekDay
{
    class Program
    {
        static void Main()
        {
            try
            {
                ExecuteMidweekDay();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ Error: {ex.Message}");
                Console.ResetColor();
                WaitForUser();
            }
        }

        static void ExecuteMidweekDay()
        {
            DisplayHeader("Midweek Day Finder");
            
            int dayNumber = GetValidatedDayNumber();
            string dayName = GetDayName(dayNumber);
            
            DisplayResult(dayNumber, dayName);
            WaitForUser();
        }

        static int GetValidatedDayNumber()
        {
            int dayNumber;
            Console.Write("Ingrese un número del 1 al 7: ");
            
            while (!int.TryParse(Console.ReadLine(), out dayNumber) || dayNumber < 1 || dayNumber > 7)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Número inválido. Ingrese un número del 1 al 7: ");
                Console.ResetColor();
            }
            
            return dayNumber;
        }

        static string GetDayName(int dayNumber)
        {
            switch (dayNumber)
            {
                case 1: return "Lunes";
                case 2: return "Martes";
                case 3: return "Miércoles";
                case 4: return "Jueves";
                case 5: return "Viernes";
                case 6:
                case 7:
                    return "Número fuera del rango laboral.";
                default:
                    return "Número inválido.";
            }
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

        static void DisplayResult(int dayNumber, string dayName)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RESULTADO:");
            Console.ResetColor();
            
            Console.WriteLine($"Número ingresado: {dayNumber}");
            
            if (dayNumber >= 1 && dayNumber <= 5)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Día de la semana: {dayName}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{dayName}");
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

