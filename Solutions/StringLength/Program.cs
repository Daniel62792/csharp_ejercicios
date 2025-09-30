using System;

namespace StringLength
{
    class Program
    {
        static void Main()
        {
            try
            {
                ExecuteStringLength();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
                WaitForUser();
            }
        }

        static void ExecuteStringLength()
        {
            DisplayHeader("String Length Calculator");
            
            string word = GetValidatedWord();
            int length = CalculateLength(word);
            
            DisplayResult(word, length);
            WaitForUser();
        }

        static string GetValidatedWord()
        {
            string word;
            Console.Write("Ingrese una palabra: ");
            word = Console.ReadLine();
            
            while (string.IsNullOrWhiteSpace(word))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Palabra inválida. Ingrese una palabra válida: ");
                Console.ResetColor();
                word = Console.ReadLine();
            }
            
            return word.Trim();
        }

        static int CalculateLength(string word)
        {
            return word.Length;
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

        static void DisplayResult(string word, int length)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RESULTADO:");
            Console.ResetColor();
            
            Console.WriteLine($"Palabra ingresada: \"{word}\"");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            if (length == 1)
            {
                Console.WriteLine($"Longitud: {length} carácter");
            }
            else
            {
                Console.WriteLine($"Longitud: {length} caracteres");
            }
            
            // Mostrar análisis adicional
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Análisis adicional:");
            Console.WriteLine($"   • Sin espacios: \"{word.Replace(" ", "")}\"");
            Console.WriteLine($"   • En mayúsculas: \"{word.ToUpper()}\"");
            Console.WriteLine($"   • En minúsculas: \"{word.ToLower()}\"");
            
            if (word.Contains(" "))
            {
                int wordCount = word.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
                Console.WriteLine($"   • Palabras: {wordCount}");
            }
        }

        static void WaitForUser()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}