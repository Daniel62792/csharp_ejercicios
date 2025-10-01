using System;
using System.Linq;

namespace VowelCounter
{
    class Program
    {
        static void Main()
        {
            try
            {
                ExecuteVowelCounter();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
                WaitForUser();
            }
        }

        static void ExecuteVowelCounter()
        {
            DisplayHeader("Vowel Counter");
            
            string word = GetValidatedWord();
            var vowelCounts = CountVowels(word);
            
            DisplayResult(word, vowelCounts);
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

        static (int total, int a, int e, int i, int o, int u) CountVowels(string word)
        {
            string lowerWord = word.ToLower();
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            
            int total = lowerWord.Count(c => vowels.Contains(c));
            int a = lowerWord.Count(c => c == 'a');
            int e = lowerWord.Count(c => c == 'e');
            int i = lowerWord.Count(c => c == 'i');
            int o = lowerWord.Count(c => c == 'o');
            int u = lowerWord.Count(c => c == 'u');
            
            return (total, a, e, i, o, u);
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

        static void DisplayResult(string word, (int total, int a, int e, int i, int o, int u) counts)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RESULTADO:");
            Console.ResetColor();
            
            Console.WriteLine($"Palabra analizada: \"{word}\"");
            Console.WriteLine($"Longitud total: {word.Length} caracteres");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Total de vocales: {counts.total}");
            Console.ResetColor();
            
            // Mostrar desglose por vocal
            Console.WriteLine();
            Console.WriteLine("Desglose por vocal:");
            
            DisplayVowelCount('A', counts.a);
            DisplayVowelCount('E', counts.e);
            DisplayVowelCount('I', counts.i);
            DisplayVowelCount('O', counts.o);
            DisplayVowelCount('U', counts.u);
            
            // Análisis adicional
            Console.WriteLine();
            Console.WriteLine("Análisis adicional:");
            
            int nonLetters = CountNonLetters(word);
            int consonants = word.Length - counts.total - nonLetters;
            Console.WriteLine($"   • Consonantes: {consonants}");
            Console.WriteLine($"   • No letras: {nonLetters}");
            Console.WriteLine($"   • Porcentaje de vocales: {(double)counts.total / word.Length * 100:F1}%");
            
            if (counts.total == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("   • ¡Esta palabra no tiene vocales!");
                Console.ResetColor();
            }
            else
            {
                char mostCommonVowel = GetMostCommonVowel(counts);
                Console.WriteLine($"   • Vocal más frecuente: {mostCommonVowel}");
            }
        }

        static void DisplayVowelCount(char vowel, int count)
        {
            string bar = new string('█', Math.Min(count, 10));
            string padding = new string(' ', 3 - count.ToString().Length);
            
            if (count > 0)
            {
                Console.WriteLine($"   {vowel}: {count}{padding} {bar}");
            }
            else
            {
                Console.WriteLine($"   {vowel}: {count}{padding} -");
            }
        }

        static int CountNonLetters(string word)
        {
            int count = 0;
            foreach (char c in word)
            {
                if (!char.IsLetter(c))
                    count++;
            }
            return count;
        }

        static char GetMostCommonVowel((int total, int a, int e, int i, int o, int u) counts)
        {
            int maxCount = Math.Max(counts.a, Math.Max(counts.e, Math.Max(counts.i, Math.Max(counts.o, counts.u))));
            
            if (maxCount == counts.a) return 'A';
            if (maxCount == counts.e) return 'E';
            if (maxCount == counts.i) return 'I';
            if (maxCount == counts.o) return 'O';
            return 'U';
        }

        static void WaitForUser()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}